using Core.Models.Newsletter;
using Data.Entities.Task;

namespace Web.Views.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageTaskViewModel
{
    public required string Token { get; init; } = null!;

    public required Data.Entities.Users.User User { get; init; } = null!;

    public required UserTask Task { get; init; }

    public required Section Section { get; init; }

    public bool? WasUpdated { get; init; }
}
