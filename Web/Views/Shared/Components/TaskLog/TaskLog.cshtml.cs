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
            Xys = Enumerable.Range(0, user.GetComponentDaysFor(Core.Models.User.Components.Tasks)).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, userLogs.Where(uw => uw.Date == date)?.Sum(t => t.Complete));
            }).Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    public Data.Entities.User.User User { get; private init; }

    public required string Token { get; init; }

    /// <summary>
    /// Distinct identifier for task images.
    /// </summary>
    public required string Name { get; init; }

    public IList<Xy> Xys { get; init; } = [];

    public Core.Models.User.Components Type => Core.Models.User.Components.Tasks;
}
