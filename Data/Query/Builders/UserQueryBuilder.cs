using Core.Models.Newsletter;
using Data.Code.Exceptions;
using Data.Entities.Users;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class UserQueryBuilder : QueryBuilderBase
{
    private readonly User User;

    private UserOptions? UserOptions;

    public UserQueryBuilder(User user, Section? section) : base(section)
    {
        User = user;
    }

    /// <summary>
    /// Filter tasks down to the user's preferences.
    /// </summary>
    public UserQueryBuilder WithUser(bool? ignored = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(UserOptions);
        UserOptions = new UserOptions(User)
        {
            Ignored = ignored,
        };

        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            TaskOptions = TaskOptions ?? new TaskOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            UserOptions = UserOptions ?? new UserOptions(User),
        };
    }
}