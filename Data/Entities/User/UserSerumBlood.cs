using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_blood")]
public class UserSerumBlood
{
    public class Consts
    {
        public const double HematocritMin = 0;
        public const double HematocritMax = 1000;
        public const double HematocritStep = .1;

        public const double HemoglobinMin = 1;
        public const double HemoglobinMax = 1000;
        public const double HemoglobinStep = .5;

        public const double MCHMin = 0;
        public const double MCHMax = 1000;
        public const double MCHStep = .1;

        public const double MCHCMin = 0;
        public const double MCHCMax = 1000;
        public const double MCHCStep = .1;

        public const double MCVMin = 0;
        public const double MCVMax = 1000;
        public const double MCVStep = .1;

        public const double MPVMin = 0;
        public const double MPVMax = 1000;
        public const double MPVStep = .1;

        public const double PlateletCountMin = 0;
        public const double PlateletCountMax = 1000;
        public const double PlateletCountStep = .1;

        public const double RBCCountMin = 0;
        public const double RBCCountMax = 1000;
        public const double RBCCountStep = .01;

        public const double RDWMin = 0;
        public const double RDWMax = 1000;
        public const double RDWStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.HematocritMin, Consts.HematocritMax)]
    [Display(Name = "Hematocrit")]
    public double? Hematocrit { get; set; }

    [Range(Consts.HemoglobinMin, Consts.HemoglobinMax)]
    [Display(Name = "Hemoglobin")]
    public double? Hemoglobin { get; set; }

    [Range(Consts.MCHMin, Consts.MCHMax)]
    [Display(Name = "MCH")]
    public double? MCH { get; set; }

    [Range(Consts.MCHCMin, Consts.MCHCMax)]
    [Display(Name = "MCHC")]
    public double? MCHC { get; set; }

    [Range(Consts.MCVMin, Consts.MCVMax)]
    [Display(Name = "MCV")]
    public double? MCV { get; set; }

    [Range(Consts.MPVMin, Consts.MPVMax)]
    [Display(Name = "MPV")]
    public double? MPV { get; set; }

    [Range(Consts.PlateletCountMin, Consts.PlateletCountMax)]
    [Display(Name = "Platelet Count")]
    public double? PlateletCount { get; set; }

    [Range(Consts.RBCCountMin, Consts.RBCCountMax)]
    [Display(Name = "RBCCount")]
    public double? RBCCount { get; set; }

    [Range(Consts.RDWMin, Consts.RDWMax)]
    [Display(Name = "RDW")]
    public double? RDW { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Hematocrit), Hematocrit },
        { nameof(Hemoglobin), Hemoglobin },
        { nameof(MCH), MCH },
        { nameof(MCHC), MCHC },
        { nameof(MCV), MCV },
        { nameof(MPV), MPV },
        { nameof(PlateletCount), PlateletCount },
        { nameof(RBCCount), RBCCount },
        { nameof(RDW), RDW },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumBloods))]
    public virtual User User { get; set; } = null!;
}
