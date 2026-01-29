using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Mood;

public class MoodViewModel
{
    public MoodViewModel(Data.Entities.Users.User user, IList<UserMood>? userMoods, int chartDays = UserConsts.ChartDaysDefault)
    {
        if (userMoods != null)
        {
            var daysBack = Enumerable.Range(0, chartDays);
            var dailyLogs = daysBack.SelectMany(i => userMoods.Where(uw => uw.Date == DateHelpers.Today.AddDays(-i)));
            var weeklyLogs = dailyLogs.GroupBy(l => l.Date.StartOfWeek()).Select(g => new Xy(g.Key, g.Average(l => l.AverageScore),
                ((Core.Models.User.Mood?)(int?)g.Average(l => l.AverageScore))?.GetSingleDisplayName()));

            Xys = weeklyLogs.Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public required UserComponentSetting Setting { get; init; } = null!;
    public UserMood UserMood { get; init; } = null!;

    internal IList<Xy> Xys { get; init; } = [];
}
