using Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_conditional_bacteria")]
[Display(Name = "Conditional Bacteria", Description = "Conditional Bacteria below have established associations with certain health conditions and are displayed based on the best levels for you. Similarly, your personalized dietary recommendations will help achieve optimal levels for you and the conditions you reported. Your percentile is compared to healthy adults.")]
public class UserGutConditionalBacteria
{
    public class Consts
    {
        public const double BacteroidesMin = 0;
        public const double BacteroidesMax = 100;
        public const double BacteroidesStep = .1;

        public const double LactobacillusMin = 0;
        public const double LactobacillusMax = 100;
        public const double LactobacillusStep = .1;

        public const double MethanobacteriaMin = 0;
        public const double MethanobacteriaMax = 100;
        public const double MethanobacteriaStep = .1;

        public const double OscillibacterMin = 0;
        public const double OscillibacterMax = 100;
        public const double OscillibacterStep = .1;

        public const double PrevotellaMin = 0;
        public const double PrevotellaMax = 100;
        public const double PrevotellaStep = .1;

        public const double RuminococcusBromiiMin = 0;
        public const double RuminococcusBromiiMax = 100;
        public const double RuminococcusBromiiStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [IdealRange(0, 15, RiskType.HighRisk)]
    [IdealRange(15, 33, RiskType.ModerateRisk)]
    [IdealRange(33, 66, RiskType.LowRisk)]
    [IdealRange(66, 85, RiskType.ModerateRisk)]
    [IdealRange(85, 100, RiskType.HighRisk)]
    [Range(Consts.BacteroidesMin, Consts.BacteroidesMax)]
    [Display(Name = "Bacteroides", Description = "Bacteroides is a large, gram-negative genus. It's especially abundant in individuals who consume a traditional Western diet, but that doesn't mean its many species are universally bad. The prebiotic inulin allows other bacteria to out-compete Bacteroides, but it responds well to arabinoxylans and pectin.")]
    public double? Bacteroides { get; set; }

    [IdealRange(0, 15, RiskType.HighRisk)]
    [IdealRange(15, 33, RiskType.ModerateRisk)]
    [IdealRange(33, 66, RiskType.LowRisk)]
    [IdealRange(66, 85, RiskType.ModerateRisk)]
    [IdealRange(85, 100, RiskType.HighRisk)]
    [Range(Consts.LactobacillusMin, Consts.LactobacillusMax)]
    [Display(Name = "Lactobacillus", Description = "Although the genus Lactobacillus is commonly consumed in probiotics, it should be considered individually based on one’s health status. It responds well to several different prebiotics. In most cases, the goal is to maximize other healthy bacteria.")]
    public double? Lactobacillus { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.MethanobacteriaMin, Consts.MethanobacteriaMax)]
    [Display(Name = "Methanobacteria", Description = "Methanobacteria is a bit of a misnomer, because they are not bacteria, but archaea. The most representative member of this class is the species <em>Methanobrevibacter smithii</em>.  To date, the only dietary component shown to increase Methanobacteria is dairy products.")]
    public double? Methanobacteria { get; set; }

    [IdealRange(0, 15, RiskType.HighRisk)]
    [IdealRange(15, 33, RiskType.ModerateRisk)]
    [IdealRange(33, 66, RiskType.LowRisk)]
    [IdealRange(66, 85, RiskType.ModerateRisk)]
    [IdealRange(85, 100, RiskType.HighRisk)]
    [Range(Consts.OscillibacterMin, Consts.OscillibacterMax)]
    [Display(Name = "Oscillibacter", Description = "This is a relatively small genus with research that supports its levels in specific conditions.")]
    public double? Oscillibacter { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.PrevotellaMin, Consts.PrevotellaMax)]
    [Display(Name = "Prevotella", Description = "Prevotella is a large genus, with <em>Prevotella copri</em> being the primary species found in the human gut. It is very high in high-fiber diets and is often associated with good health, except for a few specific conditions.")]
    public double? Prevotella { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.RuminococcusBromiiMin, Consts.RuminococcusBromiiMax)]
    [Display(Name = "Ruminococcus bromii", Description = "The strain <em>Ruminococcus bromii</em> has a clear role in gastrointestinal motility. This species is the primary degrader of resistant starch but also fuels other healthy species as it does so.")]
    public double? RuminococcusBromii { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(RuminococcusBromii), RuminococcusBromii },
        { nameof(Prevotella), Prevotella },
        { nameof(Oscillibacter), Oscillibacter },
        { nameof(Methanobacteria), Methanobacteria },
        { nameof(Bacteroides), Bacteroides },
        { nameof(Lactobacillus), Lactobacillus },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutConditionalBacteria))]
    public virtual User User { get; set; } = null!;
}
