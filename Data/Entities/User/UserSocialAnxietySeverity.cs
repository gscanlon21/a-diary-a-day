using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/69c11866-906c-4262-bfe3-753ac4ad2780/APA-DSM5TR-SeverityMeasureForSocialAnxietyDisorderAdult.pdf
/// </summary>
[Table("user_social_anxiety_severity"), Comment("User variation weight log")]
public class UserSocialAnxietySeverity
{
    public UserSocialAnxietySeverity() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? Score { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt moments of sudden terror, fear, or \r\nfright in social situation")]
    public int? Fright { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous about \r\nsocial situation")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts of being rejected, humiliated, \r\nembarrassed, ridiculed, or offending others")]
    public int? Humiliated { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble \r\nbreathing, faint, or shaky in social \r\nsituations")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, \r\nor had trouble relaxing in social situations ")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter,\r\nsocial situations")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "left social situations early or participated \r\nonly minimally (e.g., said little, avoided eye \r\ncontact)")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent a lot of time preparing what to say or \r\nhow to act in social situations")]
    public int? Preparing { get; set; }

    [Range(0, 4)]
    [Display(Name = "distracted myself to avoid thinking about \r\nsocial situation")]
    public int? DistractedMyself { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with social situations \r\n(e.g., alcohol or medications, superstitious \r\nobjects)")]
    public int? Cope { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSocialAnxietySeverities))]
    public virtual User User { get; init; } = null!;
}
