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
            var totalWeeks = Enumerable.Range(0, user.GetComponentDaysFor(Component.None)).Select(i => DateHelpers.Today.AddDays(-i).StartOfWeek()).Distinct();
            var weeklyLogs = totalWeeks.Select(week => new Xy(week, userLogs.Where(uw => uw.Date.StartOfWeek() == week).Sum(l => l.Complete)));
            Xys = weeklyLogs.Where(xy => xy.Y.HasValue).Reverse().SkipWhile(xy => xy.Y.GetValueOrDefault() == default).ToList();
        }
    }

    public Data.Entities.User.User User { get; private init; }

    public required string Token { get; init; }

    public required UserTask Task { get; init; }

    /// <summary>
    /// Distinct identifier for task images.
    /// </summary>
    public required string Name { get; init; }

    public IList<Xy> Xys { get; init; } = [];

    public Component Type => Component.None;
}
