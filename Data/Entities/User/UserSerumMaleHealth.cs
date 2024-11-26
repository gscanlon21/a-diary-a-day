using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_male_health")]
public class UserSerumMaleHealth
{
    public class Consts
    {
        public const double SHBGMin = 0;
        public const double SHBGMax = 1000;
        public const double SHBGStep = .1;

        public const double FreePSAMin = 0;
        public const double FreePSAMax = 1000;
        public const double FreePSAStep = .1;

        public const double DHEASulfateMin = 0;
        public const double DHEASulfateMax = 1000;
        public const double DHEASulfateStep = .1;

        public const double E2Min = 0;
        public const double E2Max = 1000;
        public const double E2Step = .1;

        public const double HomocysteineMin = 0;
        public const double HomocysteineMax = 1000;
        public const double HomocysteineStep = .1;

        public const double FSHMin = 0;
        public const double FSHMax = 1000;
        public const double FSHStep = .1;

        public const double LHMin = 0;
        public const double LHMax = 1000;
        public const double LHStep = .1;

        public const double ProlactinMin = 0;
        public const double ProlactinMax = 1000;
        public const double ProlactinStep = .1;

        public const double TotalPSAMin = 0;
        public const double TotalPSAMax = 1000;
        public const double TotalPSAStep = .1;

        public const double FreePSAPercentMin = 0;
        public const double FreePSAPercentMax = 1000;
        public const double FreePSAPercentStep = .1;

        public const double FreeTestosteroneMin = 0;
        public const double FreeTestosteroneMax = 1000;
        public const double FreeTestosteroneStep = .1;

        public const double TotalTestosteroneMin = 0;
        public const double TotalTestosteroneMax = 1000;
        public const double TotalTestosteroneStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.SHBGMin, Consts.SHBGMax)]
    [Display(Name = "SHBG")]
    public double? SHBG { get; set; }

    [Range(Consts.FreePSAMin, Consts.FreePSAMax)]
    [Display(Name = "Free PSA")]
    public double? FreePSA { get; set; }

    [Range(Consts.DHEASulfateMin, Consts.DHEASulfateMax)]
    [Display(Name = "DHEA Sulfate")]
    public double? DHEASulfate { get; set; }

    [Range(Consts.E2Min, Consts.E2Max)]
    [Display(Name = "E2")]
    public double? E2 { get; set; }

    [Range(Consts.FSHMin, Consts.FSHMax)]
    [Display(Name = "FSH")]
    public double? FSH { get; set; }

    [Range(Consts.LHMin, Consts.LHMax)]
    [Display(Name = "LH")]
    public double? LH { get; set; }

    [Range(Consts.ProlactinMin, Consts.ProlactinMax)]
    [Display(Name = "Prolactin")]
    public double? Prolactin { get; set; }

    [Range(Consts.TotalPSAMin, Consts.TotalPSAMax)]
    [Display(Name = "Total PSA")]
    public double? TotalPSA { get; set; }

    [Range(Consts.FreePSAPercentMin, Consts.FreePSAPercentMax)]
    [Display(Name = "Free PSA %")]
    public double? FreePSAPercent { get; set; }

    [Range(Consts.FreeTestosteroneMin, Consts.FreeTestosteroneMax)]
    [Display(Name = "Free Testosterone")]
    public double? FreeTestosterone { get; set; }

    [Range(Consts.TotalTestosteroneMin, Consts.TotalTestosteroneMax)]
    [Display(Name = "Total Testosterone")]
    public double? TotalTestosterone { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(SHBG), SHBG },
        { nameof(FreePSA), FreePSA },
        { nameof(DHEASulfate), DHEASulfate },
        { nameof(E2), E2 },
        { nameof(FSH), FSH },
        { nameof(LH), LH },
        { nameof(Prolactin), Prolactin },
        { nameof(TotalPSA), TotalPSA },
        { nameof(FreePSAPercent), FreePSAPercent },
        { nameof(FreeTestosterone), FreeTestosterone },
        { nameof(TotalTestosterone), TotalTestosterone },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumMaleHealths))]
    public virtual User User { get; set; } = null!;
}
