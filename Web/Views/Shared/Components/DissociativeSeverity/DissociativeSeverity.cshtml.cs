using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.DissociativeSeverity;


public class DissociativeSeverityViewModel
{
    public DissociativeSeverityViewModel(IList<UserDissociativeSeverity>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
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
    public Data.Entities.User.User User { get; init; } = null!;

    public UserDissociativeSeverity UserMood { get; init; } = null!;
    public UserDissociativeSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = [];
}
