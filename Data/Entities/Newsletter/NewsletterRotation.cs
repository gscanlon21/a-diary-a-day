using Microsoft.EntityFrameworkCore;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day of a user's workout split.
/// </summary>
[Owned]
public record WorkoutRotation(int Id)
{
    public string ToUserString(bool includeDay = true)
    {
        return $"";
    }
}
