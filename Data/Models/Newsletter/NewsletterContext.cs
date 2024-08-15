using Data.Entities.User;

namespace Data.Models.Newsletter;

public class NewsletterContext
{
    public User User { get; init; } = null!;
    public string Token { get; init; } = null!;
}
