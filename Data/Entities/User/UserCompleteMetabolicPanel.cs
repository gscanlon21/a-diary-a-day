using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_complete_metabolic_panel"), Comment("User variation weight log")]
public class UserCompleteMetabolicPanel : IScore
{
    public UserCompleteMetabolicPanel() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(40, 240)]
    [Display(Name = "Glucose")]
    public int? Glucose { get; set; }

    [Range(40, 240)]
    [Display(Name = "Sodium")]
    public int? Sodium { get; set; }

    [Range(40, 240)]
    [Display(Name = "Potassium")]
    public int? Potassium { get; set; }

    [Range(40, 240)]
    [Display(Name = "Chloride")]
    public int? Chloride { get; set; }

    [Range(40, 240)]
    [Display(Name = "CO2")]
    public int? CO2 { get; set; }

    [Range(40, 240)]
    [Display(Name = "Calcium")]
    public int? Calcium { get; set; }

    [Range(40, 240)]
    [Display(Name = "Anion Gap")]
    public int? AnionGap { get; set; }

    [Range(40, 240)]
    [Display(Name = "BUN")]
    public int? BUN { get; set; }

    [Range(40, 240)]
    [Display(Name = "Creatinine")]
    public int? Creatinine { get; set; }

    [Range(40, 240)]
    [Display(Name = "Alkaline Phosphatase")]
    public int? AlkalinePhosphatase { get; set; }

    [Range(40, 240)]
    [Display(Name = "ALT")]
    public int? ALT { get; set; }

    [Range(40, 240)]
    [Display(Name = "AST")]
    public int? AST { get; set; }

    [Range(40, 240)]
    [Display(Name = "Protein Total")]
    public int? ProteinTotal { get; set; }

    [Range(40, 240)]
    [Display(Name = "Albumin")]
    public int? Albumin { get; set; }

    [Range(40, 240)]
    [Display(Name = "Bilirubin Total")]
    public int? BilirubinTotal { get; set; }

    [Range(40, 240)]
    [Display(Name = "eGFR by CKD-EPI")]
    public int? EGFRbyCKDEPI { get; set; }

    [NotMapped]
    public List<int?> Items =>
    [
        Glucose, Sodium, Potassium, Chloride, CO2, Calcium, AnionGap, BUN, Creatinine, AlkalinePhosphatase, ALT, AST, ProteinTotal, Albumin, BilirubinTotal, EGFRbyCKDEPI
    ];

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? ProratedScore => Items.Any(d => d.HasValue) ? Convert.ToInt32(Items.Count * Items.Sum() / (double)Items.Count(d => d.HasValue)) : null;

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public double? AverageScore => Items.All(d => d.HasValue) ? Items.Sum() / (double)Items.Count : null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserCompleteMetabolicPanels))]
    public virtual User User { get; set; } = null!;
}
