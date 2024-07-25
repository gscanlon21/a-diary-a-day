namespace Web.Views.Shared.Components.Confirmation;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class ConfirmationViewModel
{
    public required Data.Entities.User.User User { get; init; } = null!;
}
