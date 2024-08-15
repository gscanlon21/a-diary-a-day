namespace Web.Views.Shared.Components.Newsletter;

public class NewsletterViewModel
{
    public required Data.Entities.User.User User { get; init; } = null!;

    public required string Token { get; init; } = null!;
}
