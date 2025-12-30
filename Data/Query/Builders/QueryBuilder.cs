using Core.Models.Newsletter;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder : QueryBuilderBase
{
    public QueryBuilder(Section? section) : base(section) { }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            UserOptions = new UserOptions(),
            TaskOptions = TaskOptions ?? new TaskOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
        };
    }
}