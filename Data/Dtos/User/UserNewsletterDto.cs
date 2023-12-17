using Core.Consts;
using Core.Models.Exercise;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.User;

/// <summary>
/// For the newsletter
/// </summary>
public class UserNewsletterDto(Entities.User.User user, string token)
{
    internal UserNewsletterDto(WorkoutContext context) : this(context.User, context.Token)
    {
    }

    public int Id { get; } = user.Id;

    public string Email { get; } = user.Email;

    public string Token { get; } = token;

    public Features Features { get; } = user.Features;

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; } = user.FootnoteType;

    public bool ShowStaticImages { get; } = user.ShowStaticImages;

    public bool IncludeMobilityWorkouts { get; } = user.IncludeMobilityWorkouts;

    public DateOnly? LastActive { get; } = user.LastActive;

    [Display(Name = "Send Days")]
    public Days SendDays { get; } = user.SendDays;

    [Display(Name = "Workout Verbosity")]
    public Verbosity Verbosity { get; } = user.Verbosity;

    [Display(Name = "Workout Intensity")]
    public Intensity Intensity { get; } = user.Intensity;

    [Display(Name = "Weeks Between Functional Refresh")]
    public int RefreshFunctionalEveryXWeeks { get; set; } = user.RefreshFunctionalEveryXWeeks;

    [Display(Name = "Weeks Between Accessory Refresh")]
    public int RefreshAccessoryEveryXWeeks { get; set; } = user.RefreshAccessoryEveryXWeeks;

    public int FootnoteCountTop { get; init; } = user.FootnoteCountTop;

    public int FootnoteCountBottom { get; init; } = user.FootnoteCountBottom;

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
