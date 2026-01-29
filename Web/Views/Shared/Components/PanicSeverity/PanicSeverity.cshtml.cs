using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared.Components.PanicSeverity;

public class PanicSeverityViewModel
{
    public PanicSeverityViewModel(Data.Entities.Users.User user, IList<UserPanicSeverity>? userMoods)
    {
        User = user;
        if (userMoods != null)
        {
            Xys = Enumerable.Range(0, user.GetComponentDaysFor(Component.PanicSeverity)).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new XScore(date, userMoods.FirstOrDefault(uw => uw.Date == date));
            }).Where(xy => xy.Y != null).Reverse().ToList();
        }
    }

    public Data.Entities.Users.User User { get; private init; } = null!;
    public required string Token { get; init; } = null!;

    public UserPanicSeverity UserMood { get; init; } = null!;
    public UserPanicSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = [];
}