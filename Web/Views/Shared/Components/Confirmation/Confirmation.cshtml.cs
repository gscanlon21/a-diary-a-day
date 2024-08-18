namespace Web.Views.Shared.Components.Confirmation;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class ConfirmationViewModel 
{
    public required string Token { get; init; } = null!;
    public required Data.Entities.User.User User { get; init; } = null!;
}
