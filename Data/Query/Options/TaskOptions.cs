using Core.Models.Newsletter;
using Data.Entities.Task;

namespace Data.Query.Options;

public class TaskOptions : IOptions
{
    private readonly Section _section;

    public TaskOptions() { }

    public TaskOptions(Section section)
    {
        _section = section;
    }

    /// <summary>
    /// RecipeId:Scale.
    /// </summary>
    public Dictionary<int, int>? UserTaskIds { get; private set; }

    /// <summary>
    /// Only select these recipes.
    /// </summary>
    public void AddRecipes(IEnumerable<UserTask>? recipes)
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
    public void AddRecipes(Dictionary<int, int>? recipeIds)
    {
        if (recipeIds != null)
        {
            if (UserTaskIds == null)
            {
                UserTaskIds = recipeIds;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
