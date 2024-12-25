using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.User;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder
{
    private readonly Section? Section;

    private UserOptions? UserOptions;
    private TaskOptions? TaskOptions;
    private SelectionOptions? SelectionOptions;
    private ExclusionOptions? ExclusionOptions;

    public QueryBuilder()
    {
        Section = null;
    }

    public QueryBuilder(Section? section)
    {
        Section = section;
    }

    /// <summary>
    /// Filter variations down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique exercises).
    /// </summary>
    public QueryBuilder WithUser(User user, bool? ignored = null)
    {
        UserOptions = new UserOptions(user)
        {
            Ignored = ignored,
        };

        return this;
    }

    public QueryBuilder WithUser(UserOptions userOptions, bool? ignored = null)
    {
        userOptions.Ignored = ignored ?? userOptions.Ignored;
        UserOptions = userOptions;
        return this;
    }

    public QueryBuilder WithExcludeTasks(Action<ExclusionOptions>? builder = null)
    {
        var options = ExclusionOptions ?? new ExclusionOptions();
        builder?.Invoke(options);
        ExclusionOptions = options;
        return this;
    }

    public QueryBuilder WithTaskType(UserTaskType? taskType = null, Action<TaskOptions>? builder = null)
    {
        var options = TaskOptions ?? new TaskOptions(taskType);
        builder?.Invoke(options);
        TaskOptions = options;
        return this;
    }

    public QueryBuilder WithTasks(Action<SelectionOptions>? builder = null)
    {
        var options = SelectionOptions ?? new SelectionOptions(Section);
        builder?.Invoke(options);
        SelectionOptions = options;
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            UserOptions = UserOptions ?? new UserOptions(),
            TaskOptions = TaskOptions ?? new TaskOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
        };
    }
}