using Core.Consts;
using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Anxiety;

public class AnxietyViewModel
{
    public AnxietyViewModel(IList<UserAnxiety>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(DateHelpers.Today, null)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserAnxiety UserMood { get; init; } = null!;
    public UserAnxiety? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = [];
}
