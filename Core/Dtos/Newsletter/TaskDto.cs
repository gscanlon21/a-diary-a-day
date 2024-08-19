using System.Diagnostics;

namespace Core.Dtos.Newsletter;

/// <summary>
/// DTO class for Recipe.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class TaskDto
{
    public int Id { get; init; }

    public Guid Uid { get; init; }

    public int? UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Notes about the task (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    /// <summary>
    /// When was this task last seen in the user's newsletter.
    /// </summary>
    public DateOnly LastSeen { get; init; }

    /// <summary>
    /// When was this task last marked as completed by the user.
    /// </summary>
    public DateOnly LastCompleted { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is TaskDto other
        && other.Id == Id;
}
