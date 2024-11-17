using Core.Models.Newsletter;
using Data.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's journal entry task.
/// </summary>
[Table("user_diary_task")]
public class UserDiaryTask
{
    [Obsolete("Public parameterless constructor required for EF Core.", error: true)]
    public UserDiaryTask() { }

    public UserDiaryTask(UserDiary newsletter, UserTask task)
    {
        UserDiaryId = newsletter.Id;
        UserTaskId = task.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public int UserDiaryId { get; private init; }

    public int UserTaskId { get; private init; }

    /// <summary>
    /// The order of each exercise in each section.
    /// </summary>
    public int Order { get; init; }

    /// <summary>
    /// What section of the newsletter is this?
    /// </summary>
    public Section Section { get; init; }

    [JsonIgnore, InverseProperty(nameof(Task.UserTask.UserDiaryTasks))]
    public virtual UserTask UserTask { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Newsletter.UserDiary.UserDiaryTasks))]
    public virtual UserDiary UserDiary { get; private init; } = null!;
}
