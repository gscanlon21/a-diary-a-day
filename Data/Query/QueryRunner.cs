using Core.Models.Newsletter;
using Data.Entities.Task;
using Data.Models;
using Data.Query.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Data.Query;

/// <summary>
/// Builds and runs an EF Core query for selecting exercises.
/// </summary>
public class QueryRunner(Section section)
{
    [DebuggerDisplay("{Task}")]
    public class RecipesQueryResults : IRecipeCombo
    {
        public UserTask Task { get; init; } = null!;
    }

    [DebuggerDisplay("{Task}")]
    private class InProgressQueryResults(RecipesQueryResults queryResult) :
        IRecipeCombo
    {
        public UserTask Task { get; } = queryResult.Task;

        public override int GetHashCode() => HashCode.Combine(Task.Id);

        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Task.Id == Task.Id;
    }

    public required UserOptions UserOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required TaskOptions TaskOptions { get; init; }

    private IQueryable<RecipesQueryResults> CreateFilteredRecipesQuery(CoreContext context)
    {
        return context.UserTasks.IgnoreQueryFilters().TagWith(nameof(CreateFilteredRecipesQuery))
            .Where(ev => ev.DisabledReason == null || UserOptions.IgnoreIgnored)
            .Where(t => t.UserId == UserOptions.Id)
            // Don't grab recipes that we want to ignore.
            .Where(vm => !ExclusionOptions.TaskIds.Contains(vm.Id))
            .Select(r => new RecipesQueryResults()
            {
                Task = r,
            });
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public async Task<IList<QueryResults>> Query(IServiceScopeFactory factory, int take = int.MaxValue)
    {
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var filteredQuery = CreateFilteredRecipesQuery(context);

        if (!Filters.FilterTasks(ref filteredQuery, TaskOptions.UserTaskIds))
        {
            // If there are specific tasks to select, don't filter down by Section or LastSeen date.
            filteredQuery = Filters.FilterSection(filteredQuery, section);
            filteredQuery = filteredQuery.Where(vm => vm.Task.LastSeen <= DateHelpers.Today);
            filteredQuery = filteredQuery.Where(vm => vm.Task.LastDeload.AddDays(7) <= DateHelpers.Today);
        }

        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

        // OrderBy must come after the query or you get cartesian explosion.
        var orderedResults = new List<QueryResults>();
        foreach (var recipe in queryResults
            // Order by recipes that are still pending refresh.
            .OrderByDescending(a => a.Task?.RefreshAfter.HasValue)
            // Show recipes that the user has rarely seen.
            // NOTE: When the two recipe's LastSeen dates are the same:
            // ... The LagRefreshXDays will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating recipes for the LagRefreshXDays duration.
            .ThenBy(a => a.Task?.LastSeen.DayNumber)
            // Mostly for the demo, show mostly random exercises.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read.
            .ToList())
        {
            var queryResult = new QueryResults(section, recipe.Task);
            if (!orderedResults.Contains(queryResult))
            {
                orderedResults.Add(queryResult);
            }
        }

        // REFACTORME
        return section switch
        {
            // Not in a workout context, order by name.
            Section.None => [.. orderedResults.Take(take).OrderBy(vm => vm.Task.Name)],
            // We are in a workout context, keep the result order.
            _ => orderedResults.Take(take).ToList()
        };
    }
}
