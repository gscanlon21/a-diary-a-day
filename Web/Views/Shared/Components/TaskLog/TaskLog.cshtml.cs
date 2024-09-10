using Data.Entities.Task;
using Web.ViewModels;

namespace Web.Views.Shared.Components.TaskLog;

public class TaskLogViewModel
{
    public TaskLogViewModel(Data.Entities.User.User user, IList<UserTaskLog>? userLogs)
    {
        User = user;
        if (userLogs != null)
        {
            var daysBack = Enumerable.Range(0, user.GetComponentDaysFor(Component.Tasks));
            var dailyLogs = daysBack.SelectMany(i => userLogs.Where(uw => uw.Date == DateHelpers.Today.AddDays(-i)));
            var weeklyLogs = dailyLogs.GroupBy(l => l.Date.StartOfWeek()).Select(g => new Xy(g.Key, g.Sum(l => l.Complete)));
            Xys = weeklyLogs.Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    public Data.Entities.User.User User { get; private init; }

    public required string Token { get; init; }

    /// <summary>
    /// Distinct identifier for task images.
    /// </summary>
    public required string Name { get; init; }

    public IList<Xy> Xys { get; init; } = [];

    public Component Type => Component.Tasks;
}
