﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;


/// <summary>
/// User's custom todo tasks.
/// </summary>
[Table("study")]
[DebuggerDisplay("{Name,nq}")]
public class Study
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// The title of the study.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Notes about the study.
    /// </summary>
    public string? Notes { get; set; } = null;

    /// <summary>
    /// What sections this task will show for.
    /// </summary>
    [Required]
    public string Source { get; set; } = null!;

    public string? DisabledReason { get; set; } = null;

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }


    [JsonIgnore, InverseProperty(nameof(StudySNP.Study))]
    public virtual ICollection<StudySNP> StudySNPs { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(StudySupplement.Study))]
    public virtual ICollection<StudySupplement> StudySupplements { get; private init; } = null!;


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Study other
        && other.Id == Id;
}
