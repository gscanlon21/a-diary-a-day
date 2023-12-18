using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class ManiaViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public ManiaViewModel(IList<UserMania>? userMoods)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, null)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserMania UserMood { get; init; } = null!;
    public UserMania? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = new List<Xy>();
}
