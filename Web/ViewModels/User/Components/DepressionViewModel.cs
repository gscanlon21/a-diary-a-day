using Core.Code.Helpers;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class DepressionViewModel
{
    public DepressionViewModel(IList<UserDepression>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(DateHelpers.Today, null)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserDepression UserDepression { get; init; } = null!;

    internal IList<Xy> Xys { get; init; } = [];
}
