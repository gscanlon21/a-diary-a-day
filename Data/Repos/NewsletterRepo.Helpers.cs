using Data.Entities.Newsletter;
using Data.Entities.Task;
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
        var newsletter = new UserDiary(newsletterContext.User.TodayOffset, newsletterContext);
        _context.UserDiaries.Add(newsletter); // Sets the newsletter.Id after changes are saved.
        await _context.SaveChangesAsync();

        if (tasks != null)
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                _context.UserDiaryTasks.Add(new UserDiaryTask(newsletter, task.Task)
                {
                    Section = task.Section,
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
    public async Task UpdateLastSeenDate(IEnumerable<UserTask> tasks)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        foreach (var task in tasks.DistinctBy(e => e))
        {
            // >= so that today is the last day seeing the same tasks and tomorrow the tasks will refresh.
            if (task != null && (task.RefreshAfter == null || DateHelpers.Today >= task.RefreshAfter))
            {
                var refreshAfter = task.LagRefreshXDays == 0 ? (DateOnly?)null : DateHelpers.Today.AddDays(task.LagRefreshXDays);
                // If refresh after is today, we want to see a different task tomorrow so update the last seen date.
                if (task.RefreshAfter == null && refreshAfter.HasValue && refreshAfter.Value > DateHelpers.Today)
                {
                    task.RefreshAfter = refreshAfter.Value;
                }
                else
                {
                    task.RefreshAfter = null;
                    task.LastSeen = DateHelpers.Today.AddDays(task.PadRefreshXDays);

                    // Only refresh the deload week when the refresh lag is complete.
                    // Don't update when no there's deload refresh interval.
                    if (task.DeloadAfterXWeeks > 0 && task.NeedsDeload)
                    {
                        // Add the refresh padding onto the deload week. 
                        task.LastDeload = task.LastSeen;
                    }
                }

                scopedCoreContext.UserTasks.Update(task);
            }
        }

        await scopedCoreContext.SaveChangesAsync();
    }
}
