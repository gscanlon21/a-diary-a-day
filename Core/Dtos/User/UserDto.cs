using Core.Interfaces.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// User who signed up for the newsletter.
/// </summary>
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class UserDto : IUser
{
    public int Id { get; init; }

    public Guid Uid { get; init; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    public FootnoteType FootnoteType { get; set; }

    /// <summary>
    /// Days the user want to send the newsletter.
    /// </summary>
    public Days SendDays { get; set; }

    /// <summary>
    /// What level of detail the user wants in their newsletter?
    /// </summary>
    public Verbosity Verbosity { get; set; }

    /// <summary>
    /// When was the user last active?
    /// 
    /// Is `null` when the user has not confirmed their account.
    /// </summary>
    public DateOnly? LastActive { get; set; } = null;

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    public Features Features { get; set; } = Features.None;


    #region Advanced Preferences

    public int FootnoteCountTop { get; set; }
    public int FootnoteCountBottom { get; set; }

    #endregion


    public bool IsDemoUser => Features.HasFlag(Features.Demo);
}
