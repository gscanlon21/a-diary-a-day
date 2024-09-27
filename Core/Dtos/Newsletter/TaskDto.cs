using System.Diagnostics;

namespace Core.Dtos.Newsletter;

/// <summary>
/// DTO class for UserTask.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class TaskDto
{
    public int Id { get; init; }

    public Guid Uid { get; init; }

    public int? UserId { get; init; }

    public bool ShowLog { get; init; }

    public string Name { get; init; } = null!;

    public string? Notes { get; init; } = null;

    public DateOnly LastCompleted { get; init; }

    public DateOnly LastSeen { get; init; }

    public int LagRefreshXDays { get; init; }

    public int PadRefreshXDays { get; init; }


    public string? DisabledReason { get; init; }
    public bool Enabled => string.IsNullOrWhiteSpace(DisabledReason);


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is TaskDto other
        && other.Id == Id;
}
