using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Task;

namespace Data.Query;

public interface ITaskCombo
{
    UserTask Task { get; }
}

public static class Filters
{
    /// <summary>
    /// Make sure the task is for the correct task type.
    /// </summary>
    public static IQueryable<T> FilterTaskType<T>(IQueryable<T> query, UserTaskType? value) where T : ITaskCombo
    {
        if (value.HasValue)
        {
            query = query.Where(vm => vm.Task.Type == value.Value);
        }

        return query;
    }

    /// <summary>
    /// Make sure the task is for the correct section.
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : ITaskCombo
    {
        if (value.HasValue)
        {
            if (value == Section.None)
            {
                query = query.Where(vm => vm.Task.Section == value.Value);
            }
            else
            {
                query = query.Where(vm => vm.Task.Section.HasFlag(value.Value));
            }
        }

        return query;
    }

    /// <summary>
    /// Filter down to these specific tasks.
    /// </summary>
    public static bool FilterTasks<T>(ref IQueryable<T> query, IList<int>? taskIds) where T : ITaskCombo
    {
        if (taskIds != null)
        {
            query = query.Where(vm => taskIds.Contains(vm.Task.Id));
            return true;
        }

        return false;
    }
}
