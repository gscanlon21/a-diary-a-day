using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class PosttraumaticStressSeverityViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public PosttraumaticStressSeverityViewModel(IList<UserPosttraumaticStressSeverity>? userMoods, int? currentMood)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && currentMood.HasValue)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, (int?)userMoods.FirstOrDefault(uw => uw.Date == date)?.ProratedScore);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, currentMood)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserPosttraumaticStressSeverity UserMood { get; init; } = null!;
    public UserPosttraumaticStressSeverity? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = new List<Xy>();
}
