using Core.Consts;
using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Task;


/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("user_task"), Comment("Tasks listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class UserTask
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    public string? Image { get; set; } = null;

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    /// <summary>
    /// When was this exercise last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    /// <summary>
    /// If this is set, will not update the LastSeen date until this date is reached.
    /// This is so we can reduce the variation of feasts and show the same groups of recipes for a month+ straight.
    /// </summary>
    public DateOnly? RefreshAfter { get; set; }

    /// <summary>
    /// How often to refresh exercises.
    /// </summary>
    [Required, Range(UserConsts.LagRefreshXWeeksMin, UserConsts.LagRefreshXWeeksMax)]
    public int LagRefreshXWeeks { get; set; } = UserConsts.LagRefreshXWeeksDefault;

    /// <summary>
    /// How often to refresh exercises.
    /// </summary>
    [Required, Range(UserConsts.PadRefreshXWeeksMin, UserConsts.PadRefreshXWeeksMax)]
    public int PadRefreshXWeeks { get; set; } = UserConsts.PadRefreshXWeeksDefault;

    public string? DisabledReason { get; set; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserTasks))]
    public virtual User.User User { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDiaryTask.UserTask))]
    public virtual ICollection<UserDiaryTask> UserDiaryTasks { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserTask other
        && other.Id == Id;

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
