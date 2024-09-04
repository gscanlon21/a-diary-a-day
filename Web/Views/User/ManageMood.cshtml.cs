
namespace Web.Views.User;

/// <summary>
/// For CRUD actions.
/// </summary>
public class UserManageMoodViewModel
{
    public record TheParameters(string Email, string Token);

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserManageMoodViewModel() { }

    public UserManageMoodViewModel(Core.Models.User.Components component)
    {
        Component = component;
    }

    public Core.Models.User.Components Component { get; init; }

    public required TheParameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public bool? WasUpdated { get; init; }
}
