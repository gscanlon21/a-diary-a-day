using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Task;

/// <summary>
/// User's set/rep/sec/weight tracking history of an exercise.
/// </summary>
[Table("user_task_log")]
public class UserTaskLog
{
    [Obsolete("Public parameterless constructor required for EF Core.", error: true)]
    public UserTaskLog() { }

    public UserTaskLog(Users.User user, UserTask userTask)
    {
        // Don't set UserTask, so that EF Core doesn't add/update UserTask.
        UserTaskId = userTask.Id;
        Date = user.TodayOffset;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserTaskId { get; private init; }

    public Section Section { get; set; }

    /// <summary>
    /// The date the task was completed, using the user's UTC offset date.
    /// </summary>
    [Required]
    public DateOnly Date { get; private init; }

    [Range(UserConsts.UserTaskCompleteMin, UserConsts.UserTaskCompleteMax)]
    public double Complete { get; set; } = UserConsts.UserTaskCompleteDefault;

    [JsonIgnore, InverseProperty(nameof(UserTask.UserTaskLogs))]
    public virtual UserTask UserTask { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserTaskLog other
        && other.Id == Id;
}