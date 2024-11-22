using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Task;


/// <summary>
/// User's custom todo tasks.
/// </summary>
[Table("user_task")]
[DebuggerDisplay("{Name,nq}")]
public class UserTask
{
    public class Consts
    {
        public const int OrderMin = 0;
        public const int OrderDefault = 50;
        public const int OrderMax = 500;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public Guid Uid { get; init; } = Guid.NewGuid();

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// User's notes. (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    /// <summary>
    /// User's notes. (externally shown).
    /// </summary>
    public string? InternalNotes { get; set; } = null;

    /// <summary>
    /// What sections this task will show for.
    /// </summary>
    public Section Section { get; set; }

    /// <summary>
    /// The type of the task.
    /// </summary>
    public UserTaskType Type { get; set; }

    /// <summary>
    /// The order of the task.
    /// </summary>
    [Range(Consts.OrderMin, Consts.OrderMax)]
    public int Order { get; set; } = Consts.OrderDefault;

    /// <summary>
    /// Should the task show the graph in the newsletter?
    /// </summary>
    public bool ShowLog { get; set; } = true;

    /// <summary>
    /// Keep the task in the newsletter if it was left uncompleted.
    /// </summary>
    public bool PersistUntilComplete { get; set; }

    /// <summary>
    /// When was this task last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    /// <summary>
    /// When was this task last marked as completed by the user.
    /// </summary>
    [Required]
    public DateOnly LastCompleted { get; set; }

    [NotMapped]
    public bool LastCompletedToday => LastCompleted == DateHelpers.Today;

    /// <summary>
    /// If this is set, will not update the LastSeen date until this date is reached.
    /// This is so we can reduce the variation of feasts and show the same groups of recipes for a month+ straight.
    /// </summary>
    public DateOnly? RefreshAfter { get; set; }

    // Set to 1 week in past so the deload week doesn't immediately refresh
    // ... or filter out tasks for a week after user creation.
    public DateOnly LastDeload { get; set; } = DateHelpers.Today.AddDays(-7);

    [NotMapped] // Add 1 week for the deload week duration.
    public bool NeedsDeload => LastDeload.AddDays(7) <= DateHelpers.Today.AddDays(-7 * DeloadAfterXWeeks);

    /// <summary>
    /// How often to refresh tasks.
    /// </summary>
    [Required, Range(UserConsts.LagRefreshXDaysMin, UserConsts.LagRefreshXDaysMax)]
    public int LagRefreshXDays { get; set; } = UserConsts.LagRefreshXDaysDefault;

    /// <summary>
    /// How often to refresh tasks.
    /// </summary>
    [Required, Range(UserConsts.PadRefreshXDaysMin, UserConsts.PadRefreshXDaysMax)]
    public int PadRefreshXDays { get; set; } = UserConsts.PadRefreshXDaysDefault;

    /// <summary>
    /// How often to refresh tasks.
    /// </summary>
    [Required, Range(UserConsts.DeloadWeeksMin, UserConsts.DeloadWeeksMax)]
    public int DeloadAfterXWeeks { get; set; } = UserConsts.DeloadWeeksDefault;

    /// <summary>
    /// How often to refresh tasks.
    /// </summary>
    [Required, Range(UserConsts.DeloadDurationMin, UserConsts.DeloadDurationMax)]
    public int DeloadDurationWeeks { get; set; } = UserConsts.DeloadDurationDefault;


    public string? DisabledReason { get; set; } = null;

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }


    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserTasks))]
    public virtual User.User User { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDiaryTask.UserTask))]
    public virtual ICollection<UserDiaryTask> UserDiaryTasks { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserTaskLog.UserTask))]
    public virtual ICollection<UserTaskLog> UserTaskLogs { get; private init; } = [];


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserTask other
        && other.Id == Id;
}
