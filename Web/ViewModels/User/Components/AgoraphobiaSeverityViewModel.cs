using Core.Code.Helpers;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class AgoraphobiaSeverityViewModel
{
    public AgoraphobiaSeverityViewModel(IList<UserAgoraphobiaSeverity>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new XScore(date, userMoods.FirstOrDefault(uw => uw.Date == date));
            }).Where(xy => xy.Y != null).Reverse().Append(new XScore(DateHelpers.Today, userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today))).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserAgoraphobiaSeverity UserMood { get; init; } = null!;
    public UserAgoraphobiaSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = [];
}
