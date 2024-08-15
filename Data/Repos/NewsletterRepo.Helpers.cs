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
    internal static async Task<NewsletterContext?> BuildNewsletterContext(User user, string token)
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
    internal async Task<UserDiary> CreateAndAddNewsletterToContext(NewsletterContext newsletterContext, IList<QueryResults>? tasks = null)
    {
        var newsletter = new UserDiary(DateHelpers.Today, newsletterContext);
        _context.UserDiaries.Add(newsletter); // Sets the newsletter.Id after changes are saved.
        await _context.SaveChangesAsync();

        if (tasks != null)
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                var recipe = tasks[i];
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
    internal async Task UpdateLastSeenDate(IEnumerable<QueryResults> tasks)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        foreach (var task in tasks.DistinctBy(e => e.Task))
        {
            // >= so that today is the last day seeing the same exercises and tomorrow the exercises will refresh.
            if (task.Task != null && (task.Task.RefreshAfter == null || DateHelpers.Today >= task.Task.RefreshAfter))
            {
                var refreshAfter = task.Task.LagRefreshXDays == 0 ? (DateOnly?)null : DateHelpers.Today.AddDays(task.Task.LagRefreshXDays);
                // If refresh after is today, we want to see a different exercises tomorrow so update the last seen date.
                if (task.Task.RefreshAfter == null && refreshAfter.HasValue && refreshAfter.Value > DateHelpers.Today)
                {
                    task.Task.RefreshAfter = refreshAfter.Value;
                }
                else
                {
                    task.Task.RefreshAfter = null;
                    task.Task.LastSeen = DateHelpers.Today.AddDays(task.Task.PadRefreshXDays);
                }
                scopedCoreContext.UserTasks.Update(task.Task);
            }
        }

        await scopedCoreContext.SaveChangesAsync();
    }
}
