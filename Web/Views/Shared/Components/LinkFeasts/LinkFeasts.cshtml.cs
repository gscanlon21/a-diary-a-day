using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.LinkFeasts;

public class LinkFeastsViewModel
{
    public required string Email { get; init; }
    public required string Token { get; init; }

    [Display(Name = "Feast Email")]
    public string? FeastEmail { get; init; }

    [Display(Name = "Feast Token")]
    public string? FeastToken { get; init; }
}
