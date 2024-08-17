using Core.Consts;
using Core.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Task;


/// <summary>
/// User's set/rep/sec/weight tracking history of an exercise.
/// </summary>
[Table("user_task_log"), Comment("User task log")]
public class UserTaskLog
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserTaskId { get; set; }

    public Section Section { get; set; }

    [Range(UserConsts.UserTaskCompleteMin, UserConsts.UserTaskCompleteMax)]
    public int Complete { get; set; } = UserConsts.UserTaskCompleteDefault;

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [JsonIgnore, InverseProperty(nameof(UserTask.UserTaskLogs))]
    public virtual UserTask UserTask { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserTaskLog other
        && other.Id == Id;
}