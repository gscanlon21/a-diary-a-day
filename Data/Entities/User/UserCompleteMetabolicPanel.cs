using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_complete_metabolic_panel"), Comment("User variation weight log")]
public class UserCompleteMetabolicPanel
{
    public class Consts
    {
        public const double BilirubinTotalMin = 0;
        public const double BilirubinTotalMax = 10;
        public const double BilirubinTotalStep = .1;

        public const double GlucoseMin = 50;
        public const double GlucoseMax = 200;
        public const double GlucoseStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.GlucoseMin, Consts.GlucoseMax)]
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

    [Range(Consts.BilirubinTotalMin, Consts.BilirubinTotalMax)]
    [Display(Name = "Bilirubin Total")]
    public double? BilirubinTotal { get; set; }

    [Range(40, 240)]
    [Display(Name = "eGFR by CKD-EPI")]
    public int? EGFRbyCKDEPI { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Glucose), Glucose },
        { nameof(Sodium), Sodium },
        { nameof(Potassium), Potassium },
        { nameof(Chloride), Chloride },
        { nameof(CO2), CO2 },
        { nameof(Calcium), Calcium },
        { nameof(AnionGap), AnionGap },
        { nameof(BUN), BUN },
        { nameof(Creatinine), Creatinine },
        { nameof(AlkalinePhosphatase), AlkalinePhosphatase },
        { nameof(ALT), ALT },
        { nameof(AST), AST },
        { nameof(ProteinTotal), ProteinTotal },
        { nameof(Albumin), Albumin },
        { nameof(BilirubinTotal), BilirubinTotal },
        { nameof(EGFRbyCKDEPI), EGFRbyCKDEPI },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserCompleteMetabolicPanels))]
    public virtual User User { get; set; } = null!;
}
