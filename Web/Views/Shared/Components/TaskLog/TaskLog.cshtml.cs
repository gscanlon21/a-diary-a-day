using Core.Models.Newsletter;
using Data.Entities.Task;
using Web.ViewModels;

namespace Web.Views.Shared.Components.TaskLog;

public class TaskLogViewModel
{
    public TaskLogViewModel(Data.Entities.User.User user, UserTask userTask, IList<UserTaskLog>? userLogs)
    {
        User = user;
        Task = userTask;
        if (userLogs != null)
        {
            if (userTask.Type == Core.Models.User.UserTaskType.Log)
            {
                var totalDays = Enumerable.Range(0, user.GetComponentDaysFor(Component.None)).Select(i => DateHelpers.Today.AddDays(-i)).Distinct();
                var dailyLogs = totalDays.Select(day => new Xy(day, userLogs.OrderBy(ul => ul.Id).LastOrDefault(uw => uw.Date == day)?.Complete));
                Xys = dailyLogs.Where(xy => xy.Y.HasValue).Reverse().SkipWhile(xy => xy.Y.GetValueOrDefault() == default).ToList();
            }
            else
            {
                var totalWeeks = Enumerable.Range(0, user.GetComponentDaysFor(Component.None)).Select(i => DateHelpers.Today.AddDays(-i).StartOfWeek()).Distinct();
                var weeklyLogs = totalWeeks.Select(week => new Xy(week, userLogs.Where(uw => uw.Date.StartOfWeek() == week).Sum(l => l.Complete)));
                Xys = weeklyLogs.Where(xy => xy.Y.HasValue).Reverse().SkipWhile(xy => xy.Y.GetValueOrDefault() == default).ToList();
            }
        }
    }

    public Data.Entities.User.User User { get; }
    public required Section Section { get; init; }
    public required string Token { get; init; }

    public UserTask Task { get; }

    /// <summary>
    /// Distinct identifier for task images.
    /// </summary>
    public required string Name { get; init; }

    public IList<Xy> Xys { get; init; } = [];

    public Component Type => Component.None;
}
