using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Dtos.User;

namespace Data.Dtos.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterDto(UserNewsletterDto user)
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public UserNewsletterDto User { get; } = user;

    public IList<ComponentImage> Images { get; init; }

    public IList<NewsletterTaskDto> Tasks { get; set; } = [];

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; } = user.Verbosity;
}
