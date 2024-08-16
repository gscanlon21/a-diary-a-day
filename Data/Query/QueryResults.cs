using Core.Models.Newsletter;
using Data.Entities.Task;
using Data.Query;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Section}: {Task}")]
public class QueryResults(Section section, UserTask recipe) : IRecipeCombo
{
    public Section Section { get; init; } = section;
    public UserTask Task { get; init; } = recipe;

    public override int GetHashCode() => HashCode.Combine(Task.Id);
    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Task.Id == Task.Id;
}
