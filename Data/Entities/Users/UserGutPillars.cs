using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_pillars")]
[Display(Name = "Gut Pillars", Description = "")]
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
    [Display(Name = "Digestion", Description = "Your Digestion Score is influenced by the relative abundance of beneficial microorganisms found predominantly in the colon, which are responsible for protein fermentation, and whose activity produces various metabolites, such as ammonia. A high Digestion Score reflects a lower abundance of ammonia-producing bacteria from your stool sample; ammonia being a metabolite that you want to be low.")]
    public double? Digestion { get; set; }

    [Range(Consts.InflammationMin, Consts.InflammationMax)]
    [Display(Name = "Inflammation", Description = "A low Inflammation Score means your GI tract has low levels of the bacteria known to produce inflammatory endotoxins called lipopolysaccharides and lower levels of an immunologically-derived protein called calprotectin. In elevated amounts, these inflammation responses can disrupt the normal functioning of your GI tract and immune function, and manifest as undesirable symptoms with daily discomfort.")]
    public double? Inflammation { get; set; }

    [Range(Consts.GutDysbiosisMin, Consts.GutDysbiosisMax)]
    [Display(Name = "Gut Dysbiosis", Description = "This score is based on the number and type of good bacteria present in your gut compared to the number and kind of bad bacteria present. Your high score means you have a disproportionate number of bad bacteria present. A full list of the good, bad, and conditional bacteria is in the Appendix, with details of their health benefits or risks for disease.")]
    public double? GutDysbiosis { get; set; }

    [Range(Consts.IntestinalPermeabilityMin, Consts.IntestinalPermeabilityMax)]
    [Display(Name = "Intestinal Permeability", Description = "The GI tract has a semipermeable barrier that allows the absorption of nutrients, while limiting the transport of potentially harmful antigens and microorganisms. Its effectiveness is dependent on the structural integrity and molecular interactions of the intestinal mucosa, which operates synergistically to maintain the structure and immune homeostasis.")]
    public double? IntestinalPermeability { get; set; }

    [Range(Consts.NervousSystemMin, Consts.NervousSystemMax)]
    [Display(Name = "Nervous System", Description = "A low score is desirable because it reflects a bacterial composition that is synergistically communicating with the brain to operate at a high level. An imbalance or dysregulation in the microbiome can impact mental capacity, cognitive function, and mood, including shifts in feelings of depression, anxiety, and stress.")]
    public double? NervousSystem { get; set; }

    [Range(Consts.DiversityScoreMin, Consts.DiversityScoreMax)]
    [Display(Name = "Diversity Score", Description = "Beta diversity is a measure of the quantity and the quality of microbes in your gut and compares it to other healthy adults. The higher the score, the more different your microbiome is. A lower score is better for your current health goals and future health risks.")]
    public int? DiversityScore { get; set; }

    [Range(Consts.ImmuneReadinessScoreMin, Consts.ImmuneReadinessScoreMax)]
    [Display(Name = "Immune Readiness Score", Description = "This score is calculated based on the microbes present in your gut that are responsible for a proper immune response to a foreign pathogens (virus, bacteria, parasites) and an appropriate down-regulation of your immune system after the response.")]
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

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserGutPillars))]
    public virtual User User { get; set; } = null!;
}
