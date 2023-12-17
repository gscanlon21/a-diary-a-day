using Core.Models.Exercise;

namespace Lib.ViewModels.Newsletter;

public class UserMoodViewModel
{
    public int Id { get; init; }

    public string Title()
    {
        return Date.ToLongDateString();
    }

    public string Description()
    {
        return $"{Date}";
    }

    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    public DateOnly Date { get; init; }

    /// <summary>
    /// What day of the workout split was used?
    /// </summary>
    public WorkoutRotationViewModel Rotation { get; set; } = null!;

    /// <summary>
    /// What was the workout split used when this newsletter was sent?
    /// </summary>
    public Intensity Intensity { get; init; }
}
