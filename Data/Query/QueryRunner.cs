﻿using Core.Models.Newsletter;
using Data.Entities.Task;
using Data.Query.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Security.Cryptography;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query;

/// <summary>
/// Builds and runs an EF Core query for selecting tasks.
/// </summary>
public class QueryRunner
{
    private readonly Section? _section;

    public QueryRunner(Section? section)
    {
        _section = section;
    }

    [DebuggerDisplay("{Task}")]
    public class TasksQueryResults : ITaskCombo
    {
        public UserTask Task { get; init; } = null!;
    }

    [DebuggerDisplay("{Task}")]
    private class InProgressQueryResults(TasksQueryResults queryResult) : ITaskCombo
    {
        public UserTask Task { get; } = queryResult.Task;

        public override int GetHashCode() => HashCode.Combine(Task.Id);
        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Task.Id == Task.Id;
    }

    public required UserOptions UserOptions { get; init; }
    public required TaskOptions TaskOptions { get; init; }
    public required SelectionOptions SelectionOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }

    private IQueryable<TasksQueryResults> CreateFilteredTasksQuery(CoreContext context)
    {
        return context.UserTasks.IgnoreQueryFilters().TagWith(nameof(CreateFilteredTasksQuery))
            .Where(ev => ev.DisabledReason != null || UserOptions.Ignored != true)
            .Where(ev => ev.DisabledReason == null || UserOptions.Ignored != false)
            .Where(t => t.UserId == UserOptions.Id || t.UserId == null && SelectionOptions.System)
            // Don't grab tasks that we want to ignore.
            .Where(vm => !ExclusionOptions.TaskIds.Contains(vm.Id))
            .Select(r => new TasksQueryResults()
            {
                Task = r,
            });
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public async Task<IList<QueryResults>> Query(IServiceScopeFactory factory, int take = int.MaxValue)
    {
        // When you perform comparisons with nullable types, if the value of one of the nullable types
        // ... is null and the other is not, all comparisons evaluate to false except for != (not equal).
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var filteredQuery = CreateFilteredTasksQuery(context);

        // If there are specific tasks to select, don't filter down by Section or LastSeen date.
        if (!Filters.FilterTasks(ref filteredQuery, SelectionOptions.UserTaskIds))
        {
            filteredQuery = Filters.FilterSection(filteredQuery, _section);
            filteredQuery = Filters.FilterTaskType(filteredQuery, TaskOptions.TaskType);

            if (!SelectionOptions.All)
            {
                filteredQuery = filteredQuery.Where(vm => vm.Task.LastSeen <= DateHelpers.Today);
                filteredQuery = filteredQuery.Where(vm => vm.Task.LastDeload.AddDays(7 * vm.Task.DeloadDurationWeeks) <= DateHelpers.Today);
            }
        }

        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

        // OrderBy must come after the query or you get cartesian explosion.
        var orderedResults = new List<QueryResults>();
        // Order by tasks that are still pending refresh.
        foreach (var result in queryResults.OrderByDescending(a => a.Task?.RefreshAfter.HasValue, NullOrder.NullsLast)
            // Show tasks that the user has rarely seen.
            // NOTE: When the two task's LastSeen dates are the same:
            // ... The LagRefreshXDays will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating tasks for the LagRefreshXDays duration.
            .ThenBy(a => a.Task?.LastSeen?.DayNumber, NullOrder.NullsFirst)
            // Mostly for the demo, show mostly random tasks.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read.
            .ToList())
        {
            var queryResult = new QueryResults(_section ?? Section.Anytime, result.Task);
            if (!orderedResults.Contains(queryResult))
            {
                orderedResults.Add(queryResult);
            }
        }

        return _section switch
        {
            null => [.. orderedResults.Take(take).OrderBy(vm => vm.Task.Name)],
            not null => [.. orderedResults.Take(take).OrderBy(vm => vm.Task.Order).ThenBy(vm => vm.Task.Name)]
        };
    }
}
