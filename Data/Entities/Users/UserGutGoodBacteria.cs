using Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_good_bacteria")]
[Display(Name = "Good Bacteria", Description = "The \"good bacteria\" below are well-researched and found to be highly beneficial for health. Your goal is to have and maintain average or better levels for each strain. Your percentile is compared to healthy adults.")]
public class UserGutGoodBacteria
{
    public class Consts
    {
        public const double AkkermansiaMuciniphilaMin = 0;
        public const double AkkermansiaMuciniphilaMax = 100;
        public const double AkkermansiaMuciniphilaStep = .1;

        public const double AlistipesMin = 0;
        public const double AlistipesMax = 100;
        public const double AlistipesStep = .1;

        public const double BifidobacteriumMin = 0;
        public const double BifidobacteriumMax = 100;
        public const double BifidobacteriumStep = .1;

        public const double CoprococcusMin = 0;
        public const double CoprococcusMax = 100;
        public const double CoprococcusStep = .1;

        public const double EubacteriumMin = 0;
        public const double EubacteriumMax = 100;
        public const double EubacteriumStep = .1;

        public const double EubacteriumRectaleMin = 0;
        public const double EubacteriumRectaleMax = 100;
        public const double EubacteriumRectaleStep = .1;

        public const double FaecalibacteriumPrausnitziiMin = 0;
        public const double FaecalibacteriumPrausnitziiMax = 100;
        public const double FaecalibacteriumPrausnitziiStep = .1;

        public const double LachnospiraceaeMinusBlautiaMin = 0;
        public const double LachnospiraceaeMinusBlautiaMax = 100;
        public const double LachnospiraceaeMinusBlautiaStep = .1;

        public const double OscillospiraMin = 0;
        public const double OscillospiraMax = 100;
        public const double OscillospiraStep = .1;

        public const double ParabacteroidesMin = 0;
        public const double ParabacteroidesMax = 100;
        public const double ParabacteroidesStep = .1;

        public const double RoseburiaMin = 0;
        public const double RoseburiaMax = 100;
        public const double RoseburiaStep = .1;

        public const double RuminococcusMinusRBromiiMin = 0;
        public const double RuminococcusMinusRBromiiMax = 100;
        public const double RuminococcusMinusRBromiiStep = .1;

        public const double RuminococcaceaeMin = 0;
        public const double RuminococcaceaeMax = 100;
        public const double RuminococcaceaeStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.AkkermansiaMuciniphilaMin, Consts.AkkermansiaMuciniphilaMax)]
    [Display(Name = "Akkermansia muciniphila", Description = "This is a remarkably healthy bacterium. Despite most bacteria responding well to prebiotics, this species thrives with phytochemicals as its main fuel. If low, then a diet high in fresh, colorful fruits, vegetables, seeds, and herbs would support its development.")]
    public double? AkkermansiaMuciniphila { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.AlistipesMin, Consts.AlistipesMax)]
    [Display(Name = "Alistipes", Description = "Alistipes is a genus that contains multiple species. Your goal is to increase Alistipes strains if found in low abundance.")]
    public double? Alistipes { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.BifidobacteriumMin, Consts.BifidobacteriumMax)]
    [Display(Name = "Bifidobacterium", Description = "As a genus, these strains could be the most beneficial a human possesses; the species of this genus are reported in the Probiotics section of this report. Your goal is to maximize their presence.  Bifidobacterium responds well to a variety of prebiotics from the diet.")]
    public double? Bifidobacterium { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.CoprococcusMin, Consts.CoprococcusMax)]
    [Display(Name = "Coprococcus", Description = "Coprococcus is a genus that contains about seven known species. It's a butyrate-producer, and its association with health is well-researched. Your goal is to increase Coprococcus species if found in low abundance.")]
    public double? Coprococcus { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.EubacteriumMin, Consts.EubacteriumMax)]
    [Display(Name = "Eubacterium", Description = "Eubacterium is a genus with more than a dozen species. Its abundance can decrease in individuals who follow a diet high in animal fat and protein. It produces a beneficial short-chain fatty acid – butyrate. Your goal is to increase Eubacterium species if found in low abundance.")]
    public double? Eubacterium { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.EubacteriumRectaleMin, Consts.EubacteriumRectaleMax)]
    [Display(Name = "Eubacterium rectale", Description = "This highly beneficial species is not a member of the genus Eubacterium as the name implies, but has been reclassified into the highly beneficial family Enterobacteriaceae. It is one of the predominant butyrate producers in the gut, and therefore, your goal is to maximize its presence. Fortunately, it responds well to several different prebiotics in the diet.")]
    public double? EubacteriumRectale { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.FaecalibacteriumPrausnitziiMin, Consts.FaecalibacteriumPrausnitziiMax)]
    [Display(Name = "Faecalibacterium prausnitzii", Description = "This species is considered to be one of the most beneficial individual bacterial species a human can possess and its presence should be increased in your microbiome. Like many other taxa, its butyrate production is important, but it also has direct anti-inflammatory benefits.  It responds well to several different prebiotics.")]
    public double? FaecalibacteriumPrausnitzii { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.LachnospiraceaeMinusBlautiaMin, Consts.LachnospiraceaeMinusBlautiaMax)]
    [Display(Name = "Lachnospiraceae (- Blautia)", Description = "Lachnospiraceae is a critical family within the phylum Firmicutes. It is synonymous with the often-used term Clostridial Cluster XIVa, a grouping of bacteria considered widely beneficial for health. Other than its genus Blautia, it contains many significant taxa for health, such as Anaerostipes, Butyrivibrio, Coprococcus, Lachnospira, Roseburia, and <em>E. rectale</em>. Considering these taxa at the family level gives a broader picture of this cluster, because each of the individual taxa can fluctuate. Higher levels are desirable.")]
    public double? LachnospiraceaeMinusBlautia { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.OscillospiraMin, Consts.OscillospiraMax)]
    [Display(Name = "Oscillospira", Description = "Oscillospira is a single-species genus represented by <em>Oscillospira guilliermondii</em>. It has many positive associations with health, and therefore, should be precent in abundance. It can make modest increases with various dietary prebiotics.")]
    public double? Oscillospira { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.ParabacteroidesMin, Consts.ParabacteroidesMax)]
    [Display(Name = "Parabacteroides", Description = "Parabacteroides is a genus with more than a dozen species. Feeding prebiotics will only mildly support Parabacteroides because other healthy bacteria compete for its fuel source.")]
    public double? Parabacteroides { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.RoseburiaMin, Consts.RoseburiaMax)]
    [Display(Name = "Roseburia", Description = "Roseburia is a butyrate-producing genus with several health-promoting species, most notably <em>Roseburia intestinalis</em>, <em>R. inulinivorans</em>, and <em>R. hominis</em>. The important species within this genus respond well to several different prebiotics and optimizing the presence of Roseburia species is your goal.")]
    public double? Roseburia { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.RuminococcusMinusRBromiiMin, Consts.RuminococcusMinusRBromiiMax)]
    [Display(Name = "Ruminococcus (- R bromii)", Description = "The large, health-promoting genus Ruminococcus responds mildly to several different prebiotics and is a genus you want to optimize because it is nearly universally positive.  <em>Ruminococcus bromii</em> is reported separately and has a positive role in supporting gastrointestinal motility.")]
    public double? RuminococcusMinusRBromii { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.RuminococcaceaeMin, Consts.RuminococcaceaeMax)]
    [Display(Name = "Ruminococcaceae", Description = "Ruminococcaceae is an important family within the phylum Firmicutes. It is synonymous with Clostridial Cluster IV, a grouping of bacteria considered widely beneficial for health. It contains important taxa for health, such as Oscillospira, Ruminococcus, and the significant <em>F. prausnitzii</em>. Considering these taxa at the family level gives a broader picture of this cluster, because each of the individual taxa can fluctuate. Higher levels are desirable.")]
    public double? Ruminococcaceae { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(AkkermansiaMuciniphila), AkkermansiaMuciniphila },
        { nameof(Alistipes), Alistipes },
        { nameof(Bifidobacterium), Bifidobacterium },
        { nameof(Coprococcus), Coprococcus },
        { nameof(Eubacterium), Eubacterium },
        { nameof(EubacteriumRectale), EubacteriumRectale },
        { nameof(FaecalibacteriumPrausnitzii), FaecalibacteriumPrausnitzii },
        { nameof(LachnospiraceaeMinusBlautia), LachnospiraceaeMinusBlautia },
        { nameof(Oscillospira), Oscillospira },
        { nameof(Parabacteroides), Parabacteroides },
        { nameof(Roseburia), Roseburia },
        { nameof(RuminococcusMinusRBromii), RuminococcusMinusRBromii },
        { nameof(Ruminococcaceae), Ruminococcaceae },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserGutGoodBacteria))]
    public virtual User User { get; set; } = null!;
}
