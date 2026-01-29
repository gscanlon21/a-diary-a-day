using Data.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Custom;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class CustomViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    [Display(Name = "Custom Tags")]
    public IList<UserCustom> Customs { get; init; } = null!;
}
