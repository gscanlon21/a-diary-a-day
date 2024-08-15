using Core.Dtos.Recipe;
using Core.Models.Newsletter;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Newsletter;

[DebuggerDisplay("{Section,nq}: {Variation,nq}")]
public class NewsletterTaskDto
{
    public Section Section { get; init; }

    [JsonInclude]
    public TaskDto Task { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Task);

    public override bool Equals(object? obj) => obj is NewsletterTaskDto other
        && other.Task == Task;
}
