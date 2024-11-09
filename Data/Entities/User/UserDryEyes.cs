using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://visionsource-snydereyegroup.com/wp-content/uploads/sites/958/2018/10/SPEED-II.pdf
/// 
/// Also add? TABLEA5-1_Dry_Eye_Severity_Grading_Scheme.pdf for tracking TFBUT and Schirmer scores?
/// </summary>
[Table("user_dry_eyes")]
public class UserDryEyes : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 4)]
    [Display(Name = "Dryness, Grittiness or Scratchiness")]
    public int? DrynessFrequency { get; set; }

    [Range(0, 4)]
    [Display(Name = "Soreness or Irritation")]
    public int? SorenessFrequency { get; set; }

    [Range(0, 4)]
    [Display(Name = "Burning or Watering")]
    public int? BurningFrequency { get; set; }

    [Range(0, 4)]
    [Display(Name = "Eye Fatigue")]
    public int? FatigueFrequency { get; set; }

    [Range(0, 4)]
    [Display(Name = "Dryness, Grittiness or Scratchiness")]
    public int? DrynessSeverity { get; set; }

    [Range(0, 4)]
    [Display(Name = "Soreness or Irritation")]
    public int? SorenessSeverity { get; set; }

    [Range(0, 4)]
    [Display(Name = "Burning or Watering")]
    public int? BurningSeverity { get; set; }

    [Range(0, 4)]
    [Display(Name = "Eye Fatigue")]
    public int? FatigueSeverity { get; set; }

    [Range(0, 2)]
    [Display(Name = "Last Exerienced Symptoms")]
    public int? LastExeriencedSymptoms { get; set; }

    [Display(Name = "Do you use eye drops and/or ointments?")]
    public bool EyeDrops { get; set; }

    [Display(Name = "Do the drops last 4 hours?")]
    public bool DropsLast4Hours { get; set; }

    [Display(Name = "Do any gels last 12 hours?")]
    public bool GelsLast12Hours { get; set; }

    [Display(Name = "Have you used drops today?")]
    public bool DropsUsedToday { get; set; }

    [Display(Name = "Have long are the drops effective?")]
    public int DropDuration { get; set; }

    [Display(Name = "Did you use Moisturizer, lotions or creams around eyes today?")]
    public bool MoisturizerToday { get; set; }

    [Display(Name = "Did you use makeup today?")]
    public bool MakeupToday { get; set; }

    [Display(Name = "Have you touched/rubbed your eye(s) today?")]
    public bool TouchedEyesToday { get; set; }

    [Range(0, 3)]
    [Display(Name = "Do you have fluctuating vision problems? (That can be corrected with blinking)")]
    public int? VisualBlinking { get; set; }

    [NotMapped]
    public List<int?> Items =>
    [
        DrynessFrequency, BurningFrequency, FatigueFrequency, SorenessFrequency, BurningSeverity, DrynessSeverity, FatigueSeverity, SorenessSeverity
    ];

    public int? ProratedScore => Items.Sum();

    public double? AverageScore => Items.Sum() / (double)Items.Count;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserDryEyes))]
    public virtual User User { get; init; } = null!;
}
