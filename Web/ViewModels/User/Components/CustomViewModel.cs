using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class CustomViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    [Display(Name = "Custom Tags")]
    public IList<Data.Entities.Footnote.UserCustom> Customs { get; init; } = null!;
}
