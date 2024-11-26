using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_heart")]
public class UserSerumHeart
{
    public class Consts
    {
        public const double HDLLargeMin = 0;
        public const double HDLLargeMax = 10000;
        public const double HDLLargeStep = .1;

        public const double LDLMediumMin = 0;
        public const double LDLMediumMax = 1000;
        public const double LDLMediumStep = .1;

        public const double LDLParticleNumberMin = 0;
        public const double LDLParticleNumberMax = 10000;
        public const double LDLParticleNumberStep = .1;

        public const double LDLPeakSizeMin = 0;
        public const double LDLPeakSizeMax = 1000;
        public const double LDLPeakSizeStep = .1;

        public const double LDLPatternMin = 0;
        public const double LDLPatternMax = 1000;
        public const double LDLPatternStep = .1;

        public const double LDLCholesterolMin = 0;
        public const double LDLCholesterolMax = 1000;
        public const double LDLCholesterolStep = .1;

        public const double LDLSmallMin = 0;
        public const double LDLSmallMax = 1000;
        public const double LDLSmallStep = .1;

        public const double NonHDLCholesterolMin = 0;
        public const double NonHDLCholesterolMax = 1000;
        public const double NonHDLCholesterolStep = .1;

        public const double HsCRPMin = 0;
        public const double HsCRPMax = 1000;
        public const double HsCRPStep = .1;

        public const double LipoproteinAMin = 0;
        public const double LipoproteinAMax = 1000;
        public const double LipoproteinAStep = .1;

        public const double TotalCholesterolMin = 0;
        public const double TotalCholesterolMax = 1000;
        public const double TotalCholesterolStep = .1;

        public const double TotalCholesterolHDLMin = 0;
        public const double TotalCholesterolHDLMax = 1000;
        public const double TotalCholesterolHDLStep = .1;

        public const double HDLCholesterolMin = 0;
        public const double HDLCholesterolMax = 1000;
        public const double HDLCholesterolStep = .1;

        public const double TriglyceridesMin = 0;
        public const double TriglyceridesMax = 1000;
        public const double TriglyceridesStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.HDLLargeMin, Consts.HDLLargeMax)]
    [Display(Name = "HDL Large")]
    public double? HDLLarge { get; set; }

    [Range(Consts.LDLMediumMin, Consts.LDLMediumMax)]
    [Display(Name = "LDL Medium")]
    public double? LDLMedium { get; set; }

    [Range(Consts.LDLParticleNumberMin, Consts.LDLParticleNumberMax)]
    [Display(Name = "LDL Particle Number")]
    public double? LDLParticleNumber { get; set; }

    [Range(Consts.LDLPatternMin, Consts.LDLPatternMax)]
    [Display(Name = "LDL Pattern")]
    public double? LDLPattern { get; set; }

    [Range(Consts.LDLPeakSizeMin, Consts.LDLPeakSizeMax)]
    [Display(Name = "LDL Peak Size")]
    public double? LDLPeakSize { get; set; }

    [Range(Consts.LDLSmallMin, Consts.LDLSmallMax)]
    [Display(Name = "LDL Small")]
    public double? LDLSmall { get; set; }

    [Range(Consts.LDLCholesterolMin, Consts.LDLCholesterolMax)]
    [Display(Name = "LDL Cholesterol")]
    public double? LDLCholesterol { get; set; }

    [Range(Consts.NonHDLCholesterolMin, Consts.NonHDLCholesterolMax)]
    [Display(Name = "Non HDL Cholesterol")]
    public double? NonHDLCholesterol { get; set; }

    [Range(Consts.HsCRPMin, Consts.HsCRPMax)]
    [Display(Name = "hs-CRP")]
    public double? HsCRP { get; set; }

    [Range(Consts.LipoproteinAMin, Consts.LipoproteinAMax)]
    [Display(Name = "Lipoprotein (a)")]
    public double? LipoproteinA { get; set; }

    [Range(Consts.TotalCholesterolMin, Consts.TotalCholesterolMax)]
    [Display(Name = "Total Cholesterol")]
    public double? TotalCholesterol { get; set; }

    [Range(Consts.TotalCholesterolHDLMin, Consts.TotalCholesterolHDLMax)]
    [Display(Name = "Total Cholesterol / HDL Ratio")]
    public double? TotalCholesterolHDL { get; set; }

    [Range(Consts.HDLCholesterolMin, Consts.HDLCholesterolMax)]
    [Display(Name = "HDL Cholesterol")]
    public double? HDLCholesterol { get; set; }

    [Range(Consts.TriglyceridesMin, Consts.TriglyceridesMax)]
    [Display(Name = "Triglycerides")]
    public double? Triglycerides { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(HDLLarge), HDLLarge },
        { nameof(LDLMedium), LDLMedium },
        { nameof(LDLParticleNumber), LDLParticleNumber },
        { nameof(LDLPattern), LDLPattern },
        { nameof(LDLPeakSize), LDLPeakSize },
        { nameof(LDLSmall), LDLSmall },
        { nameof(LDLCholesterol), LDLCholesterol },
        { nameof(NonHDLCholesterol), NonHDLCholesterol },
        { nameof(Triglycerides), Triglycerides },
        { nameof(HDLCholesterol), HDLCholesterol },
        { nameof(HsCRP), HsCRP },
        { nameof(LipoproteinA), LipoproteinA },
        { nameof(TotalCholesterol), TotalCholesterol },
        { nameof(TotalCholesterolHDL), TotalCholesterolHDL },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumHearts))]
    public virtual User User { get; set; } = null!;
}
