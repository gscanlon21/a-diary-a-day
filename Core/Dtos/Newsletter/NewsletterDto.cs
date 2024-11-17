using Core.Dtos.User;
using Core.Models;
using Core.Models.Newsletter;
using Core.Models.User;

namespace Core.Dtos.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterDto
{
    public DateOnly Today { get; init; } = DateHelpers.Today;

    public required UserNewsletterDto User { get; init; }
    public required UserDiaryDto UserDiary { get; init; }

    public IList<ComponentImage> Images { get; init; } = [];
    public IList<NewsletterTaskDto> Tasks { get; set; } = [];

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public required Verbosity Verbosity { get; init; }

    /// <summary>
    /// Hiding the footer in the demo iframe.
    /// </summary>
    public bool HideFooter { get; set; } = false;

    public Client Client { get; set; } = Client.Web;
}
