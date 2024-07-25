
namespace Web.Views.Shared.Components.LinkFeasts;

public class LinkFeastsViewModel
{
    public required string Email { get; init; }
    public required string Token { get; init; }

    public string? FeastEmail { get; init; }
    public string? FeastToken { get; init; }
}
