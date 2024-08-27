using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Anger;

public class AngerViewModel
{
    public AngerViewModel(IList<UserAnger>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(DateHelpers.Today, userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today)?.Annoyed)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserAnger UserMood { get; init; } = null!;
    public UserAnger? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = [];
}
