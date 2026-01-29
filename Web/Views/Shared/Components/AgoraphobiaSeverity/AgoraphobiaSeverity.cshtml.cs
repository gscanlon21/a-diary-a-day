using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared.Components.AgoraphobiaSeverity;

public class AgoraphobiaSeverityViewModel
{
    public AgoraphobiaSeverityViewModel(IList<UserAgoraphobiaSeverity>? userMoods)
    {

        if (userMoods != null)
        {
            Xys = Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new XScore(date, userMoods.FirstOrDefault(uw => uw.Date == date));
            }).Where(xy => xy.Y != null).Reverse().ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public UserAgoraphobiaSeverity UserMood { get; init; } = null!;
    public UserAgoraphobiaSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = [];
}
