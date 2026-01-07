using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User;

/// <summary>
/// For the newsletter.
/// </summary>
public class UserNewsletterDto
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserNewsletterDto() { }

    public UserNewsletterDto(UserDto user, string token)
    {
        Id = user.Id;
        Uid = user.Uid;
        Email = user.Email;
        SendDays = user.SendDays;
        Features = user.Features;
        Verbosity = user.Verbosity;
        LastActive = user.LastActive;
        CreatedDate = user.CreatedDate;
        FootnoteType = user.FootnoteType;
        FontSizeAdjust = user.FontSizeAdjust;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
        Token = token;
    }

    public int Id { get; init; }

    public Guid Uid { get; init; }

    public string Email { get; init; } = null!;

    public string Token { get; init; } = null!;

    public Features Features { get; init; }

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; init; }

    public DateOnly CreatedDate { get; init; }

    public DateOnly? LastActive { get; init; }

    [Display(Name = "Send Days")]
    public Days SendDays { get; init; }

    [Display(Name = "Email Verbosity")]
    public Verbosity Verbosity { get; init; }

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public int FontSizeAdjust { get; init; }

    public bool IsNewlyCreated => CreatedDate >= DateHelpers.Today.AddDays(-7);

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateHelpers.Today.AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
