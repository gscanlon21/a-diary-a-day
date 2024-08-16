using Data.Entities.Newsletter;

namespace Web.Views.Shared.Components.PastNewsletters;

public class PastNewslettersViewModel
{
    public IList<UserDiary> PastNewsletters { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
