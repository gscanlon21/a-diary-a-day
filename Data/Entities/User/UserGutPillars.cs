using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_pillars"), Comment("User variation weight log")]
public class UserGutPillars
{
    public class Consts
    {
        public const double DigestionMin = 0;
        public const double DigestionMax = 100;
        public const double DigestionStep = .1;

        public const double InflammationMin = 0;
        public const double InflammationMax = 100;
        public const double InflammationStep = .1;

        public const double GutDysbiosisMin = 0;
        public const double GutDysbiosisMax = 100;
        public const double GutDysbiosisStep = .1;

        public const double IntestinalPermeabilityMin = 0;
        public const double IntestinalPermeabilityMax = 100;
        public const double IntestinalPermeabilityStep = .1;

        public const double NervousSystemMin = 0;
        public const double NervousSystemMax = 100;
        public const double NervousSystemStep = .1;

        public const int DiversityScoreMin = 0;
        public const int DiversityScoreMax = 100;
        public const int DiversityScoreStep = 1;

        public const int ImmuneReadinessScoreMin = 0;
        public const int ImmuneReadinessScoreMax = 100;
        public const int ImmuneReadinessScoreStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.DigestionMin, Consts.DigestionMax)]
    [Display(Name = "Digestion")]
    public double? Digestion { get; set; }

    [Range(Consts.InflammationMin, Consts.InflammationMax)]
    [Display(Name = "Inflammation")]
    public double? Inflammation { get; set; }

    [Range(Consts.GutDysbiosisMin, Consts.GutDysbiosisMax)]
    [Display(Name = "Gut Dysbiosis")]
    public double? GutDysbiosis { get; set; }

    [Range(Consts.IntestinalPermeabilityMin, Consts.IntestinalPermeabilityMax)]
    [Display(Name = "Intestinal Permeability")]
    public double? IntestinalPermeability { get; set; }

    [Range(Consts.NervousSystemMin, Consts.NervousSystemMax)]
    [Display(Name = "Nervous System")]
    public double? NervousSystem { get; set; }

    [Range(Consts.DiversityScoreMin, Consts.DiversityScoreMax)]
    [Display(Name = "Diversity Score")]
    public int? DiversityScore { get; set; }

    [Range(Consts.ImmuneReadinessScoreMin, Consts.ImmuneReadinessScoreMax)]
    [Display(Name = "Immune Readiness Score")]
    public int? ImmuneReadinessScore { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(ImmuneReadinessScore), ImmuneReadinessScore },
        { nameof(DiversityScore), DiversityScore },
        { nameof(NervousSystem), NervousSystem },
        { nameof(IntestinalPermeability), IntestinalPermeability },
        { nameof(GutDysbiosis), GutDysbiosis },
        { nameof(Inflammation), Inflammation },
        { nameof(Digestion), Digestion },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutPillars))]
    public virtual User User { get; set; } = null!;
}
