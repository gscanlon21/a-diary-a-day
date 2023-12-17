using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/364c20fa-25a5-43cb-b6ad-a4b230ef5b70/APA-DSM5TR-SeverityOfAcuteStressSymptomsAdult.pdf
/// </summary>
[Table("user_acute_stress_severity"), Comment("User variation weight log")]
public class UserAcuteStressSeverity
{
    public UserAcuteStressSeverity() { }

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
    [Display(Name = "Having 'flashbacks', that is, you suddenly acted or felt as if a stressful experience from the past was happening all over again (for example, you reexperienced parts of a stressful experience by seeing, hearing, smelling, or physically feeling parts of the experience)?")]
    public int? Flashbacks { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling very emotionally upset when something reminded you of a stressful experience?")]
    public int? Upset { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?")]
    public int? Distant { get; set; }

    [Range(0, 4)]
    [Display(Name = "Trying to avoid thoughts, feelings, or physical sensations that reminded you of a stressful experience?")]
    public int? Avoid { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being 'super alert', on guard, or constantly on the lookout for danger?")]
    public int? Alert { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling jumpy or easily startled when you hear an unexpected noise.")]
    public int? Startled { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being extremely irritable or angry to the point where you yelled at other people, got into fights, or destroyed things?")]
    public int? Irritable { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserAcuteStressSeverities))]
    public virtual User User { get; init; } = null!;
}
