using Data.Models.Newsletter;

namespace Web.Views.Shared.Components.PastNewsletters;

public class PastNewslettersViewModel
{
    public IList<PastDiary> PastNewsletters { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
