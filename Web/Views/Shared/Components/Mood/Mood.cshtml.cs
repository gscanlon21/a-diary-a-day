using Core.Code.Extensions;
using Core.Code.Helpers;
using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Mood;

public class MoodViewModel
{
    public MoodViewModel(IList<UserMood>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            var todaysMood = userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today);
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                var userMood = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, userMood?.AverageScore, userMood?.Mood.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().Append(new Xy(DateHelpers.Today, todaysMood?.AverageScore, todaysMood?.Mood.GetSingleDisplayName())).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserMood UserMood { get; init; } = null!;

    internal IList<Xy> Xys { get; init; } = [];
}
