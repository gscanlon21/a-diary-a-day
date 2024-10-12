using Core.Models.Newsletter;
using Data.Entities.Task;
using System.Diagnostics;

namespace Data.Query;

[DebuggerDisplay("{Section}: {Task}")]
public class QueryResults : ITaskCombo
{
    public QueryResults(Section section, UserTask task)
    {
        Task = task;
        Section = section;
    }

    public UserTask Task { get; }
    public Section Section { get; }

    public override int GetHashCode() => HashCode.Combine(Task.Id);
    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Task.Id == Task.Id;
}
