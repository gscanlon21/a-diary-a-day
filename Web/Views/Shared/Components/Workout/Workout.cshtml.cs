namespace Web.Views.Shared.Components.Workout;

public class WorkoutViewModel
{
    public required Data.Entities.User.User User { get; init; } = null!;

    public required string Token { get; init; } = null!;
}
