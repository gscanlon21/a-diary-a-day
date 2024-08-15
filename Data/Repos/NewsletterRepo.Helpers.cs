using Core.Code.Helpers;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models;
using Data.Models.Newsletter;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    /// <summary>
    /// Common properties surrounding today's workout.
    /// </summary>
    internal async Task<NewsletterContext?> BuildNewsletterContext(User user, string token)
    {
        return new NewsletterContext()
        {
            User = user,
            Token = token,
        };
    }

    /// <summary>
    /// Creates a new instance of the newsletter and saves it.
    /// </summary>
    internal async Task<UserDiary> CreateAndAddNewsletterToContext(NewsletterContext newsletterContext, IList<QueryResults>? recipes = null)
    {
        var newsletter = new UserDiary(DateHelpers.Today, newsletterContext);
        _context.UserDiaries.Add(newsletter); // Sets the newsletter.Id after changes are saved.
        await _context.SaveChangesAsync();

        if (recipes != null)
        {
            for (var i = 0; i < recipes.Count; i++)
            {
                var recipe = recipes[i];
                _context.UserDiaryTasks.Add(new UserDiaryTask(newsletter, recipe.Task)
                {
                    Section = recipe.Section,
                    Order = i,
                });
            }
        }

        await _context.SaveChangesAsync();
        return newsletter;
    }

    /// <summary>
    ///     Updates the last seen date of the exercise by the user.
    /// </summary>
    /// <param name="refreshAfter">
    ///     When set and the date is > Today, hold off on refreshing the LastSeen date so that we see the same exercises in each workout.
    /// </param>
    internal async Task UpdateLastSeenDate(IEnumerable<QueryResults> recipes)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        foreach (var recipe in recipes.DistinctBy(e => e.Task))
        {
            // >= so that today is the last day seeing the same exercises and tomorrow the exercises will refresh.
            if (recipe.Task != null && (recipe.Task.RefreshAfter == null || DateHelpers.Today >= recipe.Task.RefreshAfter))
            {
                var refreshAfter = recipe.Task.LagRefreshXWeeks == 0 ? (DateOnly?)null : DateHelpers.StartOfWeek.AddDays(7 * recipe.Task.LagRefreshXWeeks);
                // If refresh after is today, we want to see a different exercises tomorrow so update the last seen date.
                if (recipe.Task.RefreshAfter == null && refreshAfter.HasValue && refreshAfter.Value > DateHelpers.Today)
                {
                    recipe.Task.RefreshAfter = refreshAfter.Value;
                }
                else
                {
                    recipe.Task.RefreshAfter = null;
                    recipe.Task.LastSeen = DateHelpers.Today.AddDays(7 * recipe.Task.PadRefreshXWeeks);
                }
                scopedCoreContext.UserTasks.Update(recipe.Task);
            }
        }

        await scopedCoreContext.SaveChangesAsync();
    }
}
