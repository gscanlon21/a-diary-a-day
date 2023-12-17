using Core.Models.User;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class DepressionSeverityViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public DepressionSeverityViewModel(IList<UserDepressionSeverity>? userMoods, int? currentMood)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && currentMood.HasValue)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, (int?)userMoods.FirstOrDefault(uw => uw.Date == date)?.Score);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, currentMood)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserDepressionSeverity UserMood { get; init; } = null!;

    internal IList<Xy> Xys { get; init; } = new List<Xy>();
}
