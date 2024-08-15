using Data.Entities.Newsletter;

namespace Web.Views.Shared.Components.PastNewsletter;

public class PastNewsletterViewModel
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public IList<UserDiary> PastNewsletters { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
