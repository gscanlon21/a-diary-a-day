using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Anxiety;

public class AnxietyViewModel
{
    public AnxietyViewModel(IList<UserAnxiety>? userMoods)
    {

        if (userMoods != null)
        {
            Xys = Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public UserAnxiety UserMood { get; init; } = null!;
    public UserAnxiety? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = [];
}
