using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_agoraphobia_severity")]
public class UserAgoraphobiaSeverity : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 4)]
    [Display(Name = "felt moments of sudden terror, fear, or fright in these situations ")]
    public int? Fright { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous about these situations")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts about panic attacks, uncomfortable physical sensations, getting lost, or being overcome with fear in these situations")]
    public int? Panic { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble breathing, faint, or shaky in these situations")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, or had trouble relaxing in these situations")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter,these situations")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "moved away from these situations, left them early, or remained close to the exit")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent a lot of time preparing for, or procrastinating about (putting off), these situations")]
    public int? Preparing { get; set; }

    [Range(0, 4)]
    [Display(Name = "distracted myself to avoid thinking about these situations.")]
    public int? Distracted { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with these situations (e.g., alcohol or medication, superstitious objects, other people)")]
    public int? Cope { get; set; }

    [NotMapped]
    public List<int?> Items =>
    [
        Fright, Nervous, Panic, Heart, Tense, Avoided, LeftEarly, Preparing, Distracted, Cope
    ];

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserAgoraphobiaSeverities))]
    public virtual User User { get; set; } = null!;
}
