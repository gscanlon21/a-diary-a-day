using Data.Entities.Task;

namespace Web.Views.Shared.Components.TaskLog;

public class TaskLogViewModel
{
    public TaskLogViewModel(IList<UserTaskLog>? userWeights, UserTask? current)
    {
        if (userWeights != null && current != null)
        {
            Xys = Enumerable.Range(0, 366).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, userWeights.Where(uw => uw.Date == date)?.Sum(t => t.Complete));
            }).Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    internal IList<Xy> Xys { get; init; } = [];

    public Core.Models.User.Components Type { get; } = Core.Models.User.Components.Tasks;

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required string Name { get; init; }

    /// <summary>
    /// For chart.js
    /// </summary>
    internal record Xy(string X, int? Y)
    {
        internal Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
    }
}
