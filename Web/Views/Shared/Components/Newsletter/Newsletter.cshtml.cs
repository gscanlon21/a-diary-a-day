namespace Web.Views.Shared.Components.Newsletter;

public class NewsletterViewModel
{
    public required Data.Entities.Users.User User { get; init; } = null!;

    public required string Token { get; init; } = null!;
}
