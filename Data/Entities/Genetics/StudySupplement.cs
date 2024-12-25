using Data.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;


/// <summary>
/// Pre-requisite exercises for other exercises
/// </summary>
[Table("study_supplement")]
[DebuggerDisplay("{Exercise} needs {PrerequisiteExercise}")]
public class StudySupplement
{
    public virtual int StudyId { get; private init; }
    public virtual int UserTaskId { get; private init; }


    [InverseProperty(nameof(Genetics.Study.StudySupplements))]
    public virtual Study Study { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Task.UserTask.StudySupplements))]
    public virtual UserTask UserTask { get; private init; } = null!;
}
