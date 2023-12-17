using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_agoraphobia_severity"), Comment("User variation weight log")]
public class UserAgoraphobiaSeverity
{
    public UserAgoraphobiaSeverity() { }

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
    [Display(Name = "felt moments of sudden terror, fear, or \r\nfright in these situations ")]
    public int? Fright { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous about \r\nthese situations")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts about panic attacks, \r\nuncomfortable physical sensations, getting \r\nlost, or being overcome with fear in these \r\nsituations\r\n")]
    public int? Panic { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble \r\nbreathing, faint, or shaky in these \r\nsituations")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, \r\nor had trouble relaxing in these situations")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter,\r\nthese situations")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "moved away from these situations, left \r\nthem early, or remained close to the exit")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent a lot of time preparing for, or \r\nprocrastinating about (putting off), these \r\nsituations")]
    public int? Preparing { get; set; }

    [Range(0, 4)]
    [Display(Name = "distracted myself to avoid thinking about \r\nthese situationss")]
    public int? Distracted { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with these situations \r\n(e.g., alcohol or medication, superstitious \r\nobjects, other people)\r\n")]
    public int? Cope { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserAgoraphobiaSeverities))]
    public virtual User User { get; init; } = null!;
}
