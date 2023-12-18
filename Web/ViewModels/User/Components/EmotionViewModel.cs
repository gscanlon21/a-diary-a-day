using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class EmotionViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public EmotionViewModel(IList<UserAcuteStressSeverity>? userMoods, int? currentMood)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && currentMood.HasValue)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new XScore(date, userMoods.FirstOrDefault(uw => uw.Date == date));
            }).Where(xy => xy.Y != null).Reverse().Append(new XScore(Today, null)).ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserAcuteStressSeverity UserMood { get; init; } = null!;
    public UserAcuteStressSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = new List<XScore>();
}
