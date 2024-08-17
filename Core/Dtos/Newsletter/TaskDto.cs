using Core.Models.Newsletter;
using System.Diagnostics;

namespace Core.Dtos.Recipe;

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
    public string Name { get; set; } = null!;

    public Section Section { get; set; }

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is TaskDto other
        && other.Id == Id;
}
