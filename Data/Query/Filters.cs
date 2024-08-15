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
    /// Make sure the exercise is for the correct workout type
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : IRecipeCombo
    {
        // Debug should be able to see all exercises.
        if (value.HasValue && value != Section.None && value != Section.Debug)
        {
            // Has any flag
            //query = query.Where(vm => (vm.Task.Section & value.Value) != 0);
        }

        return query;
    }

    /// <summary>
    /// Filter down to these specific exercises
    /// </summary>
    public static IQueryable<T> FilterRecipes<T>(IQueryable<T> query, IList<int>? exerciseIds) where T : IRecipeCombo
    {
        if (exerciseIds != null)
        {
            query = query.Where(vm => exerciseIds.Contains(vm.Task.Id));
        }

        return query;
    }
}
