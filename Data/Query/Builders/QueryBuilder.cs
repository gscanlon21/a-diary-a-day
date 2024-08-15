
using Core.Models.Newsletter;

using Data.Entities.User;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder
{
    private readonly Section Section;

    private UserOptions? UserOptions;
    private ExclusionOptions? ExclusionOptions;
    private TaskOptions? RecipeOptions;

    /// <summary>
    /// Looks for similar buckets of exercise variations.
    /// </summary>
    public QueryBuilder()
    {
        Section = Section.None;
    }

    /// <summary>
    /// Looks for similar buckets of exercise variations.
    /// </summary>
    public QueryBuilder(Section section)
    {
        Section = section;
    }

    /// <summary>
    /// Filter variations down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique exercises).
    /// </summary>
    public QueryBuilder WithUser(User user, bool ignoreIgnored = false)
    {
        UserOptions = new UserOptions(user)
        {
            IgnoreIgnored = ignoreIgnored,
        };

        return this;
    }

    public QueryBuilder WithUser(UserOptions userOptions, bool? ignoreIgnored = null)
    {
        userOptions.IgnoreIgnored = ignoreIgnored ?? userOptions.IgnoreIgnored;
        UserOptions = userOptions;
        return this;
    }

    public QueryBuilder WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
    {
        var options = ExclusionOptions ?? new ExclusionOptions();
        builder?.Invoke(options);
        ExclusionOptions = options;
        return this;
    }

    public QueryBuilder WithRecipes(Action<TaskOptions>? builder = null)
    {
        var options = RecipeOptions ?? new TaskOptions(Section);
        builder?.Invoke(options);
        RecipeOptions = options;
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
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            RecipeOptions = RecipeOptions ?? new TaskOptions(),
        };
    }
}