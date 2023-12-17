using Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageMoodViewModel
{
    public record TheParameters(string Email, string Token);

    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserManageMoodViewModel() { }

    public UserManageMoodViewModel(IList<UserMood>? userWeights, int? currentWeight)
    {
        Mood = currentWeight.GetValueOrDefault();
        if (userWeights != null && currentWeight.HasValue)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new Xy(date, (int?)userWeights.FirstOrDefault(uw => uw.Date == date)?.Mood);
            }).Where(xy => xy.Y.HasValue).Reverse().Append(new Xy(Today, currentWeight)).ToList();
        }
    }

    public required TheParameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public bool? WasUpdated { get; init; }

    [Range(1, 5)]
    [Display(Name = "How was your day?")]
    public int? Mood { get; init; }

    internal IList<Xy> Xys { get; init; } = new List<Xy>();

    /// <summary>
    /// For chart.js
    /// </summary>
    internal record Xy(string X, int? Y)
    {
        internal Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
    }
}
