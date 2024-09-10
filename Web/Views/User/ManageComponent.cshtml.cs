namespace Web.Views.User;

/// <summary>
/// For CRUD actions.
/// </summary>
public class UserManageComponentViewModel
{
    public record TheParameters(string Email, string Token);

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserManageComponentViewModel() { }

    public UserManageComponentViewModel(Component component)
    {
        Component = component;
    }

    public Component Component { get; init; }

    public required TheParameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public bool? WasUpdated { get; init; }
}
