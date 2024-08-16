using Core.Models.Newsletter;
using Data.Entities.Task;

namespace Data.Query;

public interface IRecipeCombo
{
    UserTask Task { get; }
}

public static class Filters
{
    /// <summary>
    /// Make sure the exercise is for the correct task type
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : IRecipeCombo
    {
        if (value.HasValue && value != Section.None)
        {
            query = query.Where(vm => vm.Task.Section.HasFlag(value.Value));
        }

        return query;
    }

    /// <summary>
    /// Filter down to these specific tasks
    /// </summary>
    public static bool FilterTasks<T>(ref IQueryable<T> query, IList<int>? taskIds) where T : IRecipeCombo
    {
        if (taskIds != null)
        {
            query = query.Where(vm => taskIds.Contains(vm.Task.Id));
            return true;
        }

        return false;
    }
}
