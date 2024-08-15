using Data.Entities.User;

namespace Web.Views.Shared.Components.PastWorkout;

public class PastWorkoutViewModel
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public IList<UserMood> PastWorkouts { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
