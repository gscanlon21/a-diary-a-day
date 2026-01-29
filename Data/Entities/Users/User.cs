using Core.Interfaces.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// User who signed up for the newsletter.
/// </summary>
[Table("user")]
[Index(nameof(Email), IsUnique = true)]
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class User : IUser
{
    public class Consts
    {
        public const int FootnoteCountMin = 1;
        public const int FootnoteCountTopDefault = 2;
        public const int FootnoteCountBottomDefault = 2;
        public const int FootnoteCountMax = 4;
    }

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public User() { }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    public User(string email, bool acceptedTerms)
    {
        if (!acceptedTerms)
        {
            throw new ArgumentException("User must accept the Terms of Use.", nameof(acceptedTerms));
        }

        Email = email.Trim();
        AcceptedTerms = acceptedTerms;
        CreatedDate = DateHelpers.Today;
        SendDays = UserConsts.DaysDefault;
        SendHour = UserConsts.SendHourDefault;
        Verbosity = UserConsts.VerbosityDefault;
        FootnoteType = UserConsts.FootnotesDefault;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public Guid Uid { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The user's email address.
    /// </summary>
    [Required]
    public string Email { get; private init; } = null!;

    /// <summary>
    /// User has accepted the current Terms of Use when they signed up.
    /// </summary>
    [Required]
    public bool AcceptedTerms { get; private init; }

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    [Required]
    public FootnoteType FootnoteType { get; set; }

    /// <summary>
    /// Days the user want to skip the newsletter.
    /// </summary>
    [NotMapped]
    public Days RestDays => Days.All & ~SendDays;

    /// <summary>
    /// Days the user want to send the newsletter.
    /// </summary>
    [Required]
    public Days SendDays { get; set; }

    /// <summary>
    /// What hour of the day (UTC) should we send emails to this user.
    /// </summary>
    [Required, Range(UserConsts.SendHourMin, UserConsts.SendHourMax)]
    public int SendHour { get; set; } = UserConsts.SendHourDefault;

    [Required, Range(UserConsts.FontSizeAdjustMin, UserConsts.FontSizeAdjustMax)]
    public int FontSizeAdjust { get; set; } = UserConsts.FontSizeAdjustDefault;

    /// <summary>
    /// Offset of today taking into account the user's SendHour.
    /// </summary>
    public DateOnly TodayOffset => DateOnly.FromDateTime(DateTime.UtcNow.AddHours(-1 * SendHour));

    /// <summary>
    /// When this user was created.
    /// </summary>
    [Required]
    public DateOnly CreatedDate { get; private init; }

    /// <summary>
    /// What level of detail the user wants in their newsletter?
    /// </summary>
    [Required]
    public Verbosity Verbosity { get; set; }

    /// <summary>
    /// When was the user last active?
    /// 
    /// Is `null` when the user has not confirmed their account.
    /// </summary>
    public DateOnly? LastActive { get; set; } = null;

    /// <summary>
    /// User would like to receive the workouts in emails?
    /// </summary>
    public string? NewsletterDisabledReason { get; set; } = null;

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    public Component Components { get; set; } = Component.All;

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    public Features Features { get; set; } = Features.None;

    public string? FeastEmail { get; set; }
    public string? FeastToken { get; set; }


    #region NotMapped

    /// <summary>
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public bool IsDemoUser => Features.HasFlag(Features.Demo);

    /// <summary>
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public bool NewsletterEnabled => NewsletterDisabledReason == null;

    #endregion
    #region Advanced Preferences

    /// <summary>
    /// User footnotes.
    /// </summary>
    public int FootnoteCountTop { get; set; } = Consts.FootnoteCountTopDefault;

    /// <summary>
    /// System footnotes.
    /// </summary>
    public int FootnoteCountBottom { get; set; } = Consts.FootnoteCountBottomDefault;

    #endregion
    #region Navigation Properties

    [JsonInclude, InverseProperty(nameof(UserComponentSetting.User))]
    public virtual ICollection<UserComponentSetting> UserComponentSettings { get; init; } = [];
    public int GetComponentDaysFor(Component component) => UserComponentSettings.FirstOrDefault(ucs => ucs.Component == component)?.Days ?? UserConsts.ChartDaysDefault;

    [JsonIgnore, InverseProperty(nameof(UserToken.User))]
    public virtual ICollection<UserToken> UserTokens { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserComponent.User))]
    public virtual ICollection<UserComponent> UserComponents { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserMood.User))]
    public virtual ICollection<UserMood> UserMoods { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserDepression> UserDepressions { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserJournal.User))]
    public virtual ICollection<UserJournal> UserJournals { get; private init; } = null!;

    [JsonInclude, InverseProperty(nameof(UserTask.User))]
    public virtual ICollection<UserTask> UserTasks { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserEmail.User))]
    public virtual ICollection<UserEmail> UserEmails { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserFootnote.User))]
    public virtual ICollection<UserFootnote> UserFootnotes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserCustom.User))]
    public virtual ICollection<UserCustom> UserCustoms { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserAcuteStressSeverity> UserAcuteStressSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserAgoraphobiaSeverity> UserAgoraphobiaSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserCompleteMetabolicPanel.User))]
    public virtual ICollection<UserCompleteMetabolicPanel> UserCompleteMetabolicPanels { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserCbcWAutoDiff.User))]
    public virtual ICollection<UserCbcWAutoDiff> UserCbcWAutoDiffs { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutPillars.User))]
    public virtual ICollection<UserGutPillars> UserGutPillars { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutFungi.User))]
    public virtual ICollection<UserGutFungi> UserGutFungi { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutConditionalBacteria.User))]
    public virtual ICollection<UserGutConditionalBacteria> UserGutConditionalBacteria { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutGoodBacteria.User))]
    public virtual ICollection<UserGutGoodBacteria> UserGutGoodBacteria { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutBadBacteria.User))]
    public virtual ICollection<UserGutBadBacteria> UserGutBadBacteria { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutPathogens.User))]
    public virtual ICollection<UserGutPathogens> UserGutPathogens { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutProbiotics.User))]
    public virtual ICollection<UserGutProbiotics> UserGutProbiotics { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutMicronutrients.User))]
    public virtual ICollection<UserGutMicronutrients> UserGutMicronutrients { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserGutShortChainFattyAcids.User))]
    public virtual ICollection<UserGutShortChainFattyAcids> UserGutShortChainFattyAcids { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserBloodWork.User))]
    public virtual ICollection<UserBloodWork> UserBloodWorks { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserBloodPressure.User))]
    public virtual ICollection<UserBloodPressure> UserBloodPressures { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserBodyTemp.User))]
    public virtual ICollection<UserBodyTemp> UserBodyTemps { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserAnger> UserAngers { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserAnxiety> UserAnxieties { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserDepressionSeverity> UserDepressionSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserDissociativeSeverity> UserDissociativeSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserGeneralizedAnxietySeverity> UserGeneralizedAnxietySeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserMania> UserManias { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserPanicSeverity> UserPanicSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserPostTraumaticStressSeverity> UserPostTraumaticStressSeverities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserDepression.User))]
    public virtual ICollection<UserSocialAnxietySeverity> UserSocialAnxietySeverities { get; private init; } = null!;


    [JsonIgnore, InverseProperty(nameof(UserSymptom.User))]
    public virtual ICollection<UserSymptom> UserSymptoms { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserActivity.User))]
    public virtual ICollection<UserActivity> UserActivities { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserDryEyes.User))]
    public virtual ICollection<UserDryEyes> UserDryEyes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserAllergens.User))]
    public virtual ICollection<UserAllergens> UserAllergens { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserPeople.User))]
    public virtual ICollection<UserPeople> UserPeoples { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserMedicine.User))]
    public virtual ICollection<UserMedicine> UserMedicines { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSleep.User))]
    public virtual ICollection<UserSleep> UserSleeps { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserEmotion.User))]
    public virtual ICollection<UserEmotion> UserEmotions { get; private init; } = null!;


    [JsonIgnore, InverseProperty(nameof(UserUrine.User))]
    public virtual ICollection<UserUrine> UserUrines { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSalivaStress.User))]
    public virtual ICollection<UserSalivaStress> UserSalivaStress { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumThyroid.User))]
    public virtual ICollection<UserSerumThyroid> UserSerumThyroids { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSerumStress.User))]
    public virtual ICollection<UserSerumStress> UserSerumStress { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSerumPancreas.User))]
    public virtual ICollection<UserSerumPancreas> UserSerumPancreas { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSerumNutrients.User))]
    public virtual ICollection<UserSerumNutrients> UserSerumNutrients { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumMetabolic.User))]
    public virtual ICollection<UserSerumMetabolic> UserSerumMetabolics { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumMaleHealth.User))]
    public virtual ICollection<UserSerumMaleHealth> UserSerumMaleHealths { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumLiver.User))]
    public virtual ICollection<UserSerumLiver> UserSerumLivers { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumKidney.User))]
    public virtual ICollection<UserSerumKidney> UserSerumKidneys { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumImmuneRegulation.User))]
    public virtual ICollection<UserSerumImmuneRegulation> UserSerumImmuneRegulations { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSerumHeavyMetals.User))]
    public virtual ICollection<UserSerumHeavyMetals> UserSerumHeavyMetals { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumHeart.User))]
    public virtual ICollection<UserSerumHeart> UserSerumHearts { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumFemaleHealth.User))]
    public virtual ICollection<UserSerumFemaleHealth> UserSerumFemaleHealths { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSerumElectrolytes.User))]
    public virtual ICollection<UserSerumElectrolytes> UserSerumElectrolytes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumBlood.User))]
    public virtual ICollection<UserSerumBlood> UserSerumBloods { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserSerumAutoimmunity.User))]
    public virtual ICollection<UserSerumAutoimmunity> UserSerumAutoimmunitys { get; private init; } = null!;


    #endregion
}
