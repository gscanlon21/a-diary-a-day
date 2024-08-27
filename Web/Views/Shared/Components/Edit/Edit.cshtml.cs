using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Web.Views.Index;

namespace Web.Views.Shared.Components.Edit;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserEditViewModel
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserEditViewModel() { }

    public UserEditViewModel(Data.Entities.User.User user, string token)
    {
        User = user;
        Email = user.Email;
        SendDays = user.SendDays;
        NewsletterEnabled = user.NewsletterEnabled;
        NewsletterDisabledReason = user.NewsletterDisabledReason;
        Verbosity = user.Verbosity;
        FootnoteType = user.FootnoteType;
        SendHour = user.SendHour;
        Components = user.Components;
        Token = token;
    }

    [ValidateNever]
    public Data.Entities.User.User User { get; set; } = null!;

    public string Token { get; set; } = null!;

    /// <summary>
    /// If null, user has not yet tried to update.
    /// If true, user has successfully updated.
    /// If false, user failed to update.
    /// </summary>
    public bool? WasUpdated { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required, RegularExpression(UserCreateViewModel.EmailRegex, ErrorMessage = UserCreateViewModel.EmailRegexError)]
    [Display(Name = "Email", Description = "")]
    public string Email { get; init; } = null!;

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    [Display(Name = "Footnotes", Description = "What types of footnotes do you want to see?")]
    public FootnoteType FootnoteType { get; set; }

    [Display(Name = "Disabled Reason")]
    public string? NewsletterDisabledReason { get; init; }

    [Display(Name = "Subscribe to Emails", Description = "Receive your health insights via email.")]
    public bool NewsletterEnabled { get; init; }

    [Required]
    [Display(Name = "Email Verbosity", Description = "What level of detail do you want to receive in each email?")]
    public Verbosity Verbosity { get; set; }

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    [Required]
    public Core.Models.User.Components Components { get; set; }

    [Required, Range(UserConsts.SendHourMin, UserConsts.SendHourMax)]
    [Display(Name = "Send Time (UTC)", Description = "What hour of the day (UTC) do you want to receive new emails?")]
    public int SendHour { get; init; }

    [Display(Name = "Component Settings")]
    public IList<UserEditComponentSkillViewModel> UserComponentSettings { get; set; } = [];

    [Required]
    [Display(Name = "Send Days", Description = "What days do you want to receive new emails?")]
    public Days SendDays { get; private set; }

    public Core.Models.User.Components[]? ComponentsBinder
    {
        get => EnumExtensions.GetValuesExcluding32(Core.Models.User.Components.None).Where(e => Components.HasFlag(e)).ToArray();
        set => Components = value?.Aggregate(Core.Models.User.Components.None, (a, e) => a | e) ?? Core.Models.User.Components.None;
    }

    public Verbosity[]? VerbosityBinder
    {
        get => Enum.GetValues<Verbosity>().Where(e => Verbosity.HasFlag(e)).ToArray();
        set => Verbosity = value?.Aggregate(Verbosity.None, (a, e) => a | e) ?? Verbosity.None;
    }

    public FootnoteType[]? FootnoteTypeBinder
    {
        get => Enum.GetValues<FootnoteType>().Where(e => FootnoteType.HasFlag(e)).ToArray();
        set => FootnoteType = value?.Aggregate(FootnoteType.None, (a, e) => a | e) ?? FootnoteType.None;
    }

    public Days[]? SendDaysBinder
    {
        get => Enum.GetValues<Days>().Where(e => SendDays.HasFlag(e)).ToArray();
        set => SendDays = value?.Aggregate(Days.None, (a, e) => a | e) ?? Days.None;
    }

    [DebuggerDisplay("{Component}: {Days}")]
    public class UserEditComponentSkillViewModel
    {
        public UserEditComponentSkillViewModel() { }

        public UserEditComponentSkillViewModel(UserComponentSetting userComponentSetting)
        {
            Days = userComponentSetting.Days;
            UserId = userComponentSetting.UserId;
            Component = userComponentSetting.Component;
        }

        public int UserId { get; init; }

        public Core.Models.User.Components Component { get; init; }

        [Range(UserConsts.ChartDaysMin, UserConsts.ChartDaysMax)]
        public int Days { get; init; } = UserConsts.ChartDaysDefault;
    }
}
