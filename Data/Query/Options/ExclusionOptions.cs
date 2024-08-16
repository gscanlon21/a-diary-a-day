using Data.Entities.Task;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any recipes that fall in this list.
    /// </summary>
    public List<int> TaskIds = [];

    /// <summary>
    /// Exclude any of these recipes from being chosen.
    /// </summary>
    internal void AddExcludeTasks(IEnumerable<UserTask>? tasks)
    {
        if (tasks != null)
        {
            TaskIds.AddRange(tasks.Select(e => e.Id));
        }
    }
}
