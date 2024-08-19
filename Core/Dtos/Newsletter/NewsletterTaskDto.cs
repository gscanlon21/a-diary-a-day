using Core.Models.Newsletter;
using System.Diagnostics;

namespace Core.Dtos.Newsletter;

[DebuggerDisplay("{Section,nq}: {Task,nq}")]
public class NewsletterTaskDto
{
    public Section Section { get; init; }

    public TaskDto Task { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Task);
    public override bool Equals(object? obj) => obj is NewsletterTaskDto other
        && other.Task == Task;
}
