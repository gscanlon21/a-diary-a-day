using Core.Models.Newsletter;
using Core.Models.User;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public abstract class QueryBuilderBase
{
    protected readonly Section? Section;

    protected TaskOptions? TaskOptions;
    protected SelectionOptions? SelectionOptions;
    protected ExclusionOptions? ExclusionOptions;

    public QueryBuilderBase(Section? section)
    {
        Section = section;
    }

    public virtual QueryBuilderBase WithExcludeTasks(Action<ExclusionOptions>? builder = null)
    {
        var options = ExclusionOptions ?? new ExclusionOptions();
        builder?.Invoke(options);
        ExclusionOptions = options;
        return this;
    }

    public virtual QueryBuilderBase WithTaskType(UserTaskType? taskType = null, Action<TaskOptions>? builder = null)
    {
        var options = TaskOptions ?? new TaskOptions(taskType);
        builder?.Invoke(options);
        TaskOptions = options;
        return this;
    }

    public virtual QueryBuilderBase WithTasks(Action<SelectionOptions>? builder = null)
    {
        var options = SelectionOptions ?? new SelectionOptions(Section);
        builder?.Invoke(options);
        SelectionOptions = options;
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public abstract QueryRunner Build();
}