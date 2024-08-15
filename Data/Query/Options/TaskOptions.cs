using Data.Entities.Newsletter;
using Data.Entities.Task;

namespace Data.Query.Options;

public class TaskOptions : IOptions
{
    public TaskOptions() { }

    /// <summary>
    /// RecipeId:Scale.
    /// </summary>
    public Dictionary<int, int>? UserTaskIds { get; private set; }

    /// <summary>
    /// Only select these recipes.
    /// </summary>
    public void AddTasks(IEnumerable<UserDiaryTask>? recipes)
    {
        if (recipes != null)
        {
            if (UserTaskIds == null)
            {
                UserTaskIds = recipes.ToDictionary(nv => nv.Id, nv => 1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Only select these recipes.
    /// </summary>
    public void AddTasks(IEnumerable<UserTask>? recipes)
    {
        if (recipes != null)
        {
            if (UserTaskIds == null)
            {
                UserTaskIds = recipes.ToDictionary(nv => nv.Id, nv => 1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
