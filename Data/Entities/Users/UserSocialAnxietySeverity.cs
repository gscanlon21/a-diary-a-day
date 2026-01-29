using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/69c11866-906c-4262-bfe3-753ac4ad2780/APA-DSM5TR-SeverityMeasureForSocialAnxietyDisorderAdult.pdf
/// </summary>
[Table("user_social_anxiety_severity")]
public class UserSocialAnxietySeverity : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 4)]
    [Display(Name = "felt moments of sudden terror, fear, or fright in social situation")]
    public int? Fright { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous about social situation")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts of being rejected, humiliated, embarrassed, ridiculed, or offending others")]
    public int? Humiliated { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble breathing, faint, or shaky in social situations")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, or had trouble relaxing in social situations ")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter,social situations")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "left social situations early or participated only minimally (e.g., said little, avoided eye contact)")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent a lot of time preparing what to say or how to act in social situations")]
    public int? Preparing { get; set; }

    [Range(0, 4)]
    [Display(Name = "distracted myself to avoid thinking about social situation")]
    public int? DistractedMyself { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with social situations (e.g., alcohol or medications, superstitious objects)")]
    public int? Cope { get; set; }

    [NotMapped]
    public List<int?> Items =>
    [
        Cope, DistractedMyself, Preparing, LeftEarly, Avoided, Tense, Heart, Fright, Humiliated, Nervous
    ];

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSocialAnxietySeverities))]
    public virtual User User { get; set; } = null!;
}
