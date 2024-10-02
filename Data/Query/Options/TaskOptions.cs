using Core.Models.User;

namespace Data.Query.Options;

public class TaskOptions : IOptions
{
    public TaskOptions() { }

    public TaskOptions(UserTaskType? taskType)
    {
        TaskType = taskType;
    }

    /// <summary>
    /// Only select tasks of this type.
    /// </summary>
    public UserTaskType? TaskType { get; private init; }
}
