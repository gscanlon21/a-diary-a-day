using Core.Models.Newsletter;
using Data.Entities.Newsletter;
using Data.Entities.Task;

namespace Data.Query.Options;

public class SelectionOptions : IOptions
{
    private readonly Section _section;

    public SelectionOptions() { }

    public SelectionOptions(Section section)
    {
        _section = section;
    }

    public bool All { get; set; } = false;

    /// <summary>
    /// A list of task ids to select.
    /// </summary>
    public IList<int>? UserTaskIds { get; private set; }

    /// <summary>
    /// Only select these tasks.
    /// </summary>
    public void AddTasks(IEnumerable<UserDiaryTask>? tasks)
    {
        if (tasks != null)
        {
            if (UserTaskIds == null)
            {
                UserTaskIds = tasks.Where(t => _section == t.Section).Select(t => t.UserTaskId).ToList();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Only select these tasks.
    /// </summary>
    public void AddTasks(IEnumerable<UserTask>? tasks)
    {
        if (tasks != null)
        {
            if (UserTaskIds == null)
            {
                UserTaskIds = tasks.Select(t => t.Id).ToList();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
