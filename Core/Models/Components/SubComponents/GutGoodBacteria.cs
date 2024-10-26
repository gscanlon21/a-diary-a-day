using System.ComponentModel.DataAnnotations;

namespace Core.Models.Components.SubComponents;

[Flags]
public enum GutGoodBacteria
{
    None = 0,

    [Display(Name = "Akkermansia muciniphila", Description = "This is a remarkably healthy bacterium. Despite most bacteria responding well to prebiotics, this species thrives with phytochemicals as its main fuel. If low, then a diet high in fresh, colorful fruits, vegetables, seeds, and herbs would support its development.")]
    AkkermansiaMuciniphila = 1 << 0, // 1

    [Display(Name = "Alistipes", Description = "Alistipes is a genus that contains multiple species. Your goal is to increase Alistipes strains if found in low abundance.")]
    Alistipes = 1 << 1, // 2

    [Display(Name = "Bifidobacterium", Description = "As a genus, these strains could be the most beneficial a human possesses; the species of this genus are reported in the Probiotics section of this report. Your goal is to maximize their presence.  Bifidobacterium responds well to a variety of prebiotics from the diet.")]
    Bifidobacterium = 1 << 2, // 2

    [Display(Name = "Coprococcus", Description = "Coprococcus is a genus that contains about seven known species. It's a butyrate-producer, and its association with health is well-researched. Your goal is to increase Coprococcus species if found in low abundance.")]
    Coprococcus = 1 << 3, // 2

    [Display(Name = "Eubacterium", Description = "Eubacterium is a genus with more than a dozen species. Its abundance can decrease in individuals who follow a diet high in animal fat and protein. It produces a beneficial short-chain fatty acid – butyrate. Your goal is to increase Eubacterium species if found in low abundance.")]
    Eubacterium = 1 << 4, // 2

    [Display(Name = "Eubacterium rectale", Description = "This highly beneficial species is not a member of the genus Eubacterium as the name implies, but has been reclassified into the highly beneficial family Enterobacteriaceae. It is one of the predominant butyrate producers in the gut, and therefore, your goal is to maximize its presence. Fortunately, it responds well to several different prebiotics in the diet.")]
    EubacteriumRectale = 1 << 5, // 2

    [Display(Name = "Faecalibacterium prausnitzii", Description = "This species is considered to be one of the most beneficial individual bacterial species a human can possess and its presence should be increased in your microbiome. Like many other taxa, its butyrate production is important, but it also has direct anti-inflammatory benefits.  It responds well to several different prebiotics.")]
    FaecalibacteriumPrausnitzii = 1 << 6, // 2

    [Display(Name = "Lachnospiraceae (- Blautia)", Description = "Lachnospiraceae is a critical family within the phylum Firmicutes. It is synonymous with the often-used term Clostridial Cluster XIVa, a grouping of bacteria considered widely beneficial for health. Other than its genus Blautia, it contains many significant taxa for health, such as Anaerostipes, Butyrivibrio, Coprococcus, Lachnospira, Roseburia, and <em>E. rectale</em>. Considering these taxa at the family level gives a broader picture of this cluster, because each of the individual taxa can fluctuate. Higher levels are desirable.")]
    LachnospiraceaeMinusBlautia = 1 << 7, // 2

    [Display(Name = "Oscillospira", Description = "Oscillospira is a single-species genus represented by <em>Oscillospira guilliermondii</em>. It has many positive associations with health, and therefore, should be precent in abundance. It can make modest increases with various dietary prebiotics.")]
    Oscillospira = 1 << 8, // 2

    [Display(Name = "Parabacteroides", Description = "Parabacteroides is a genus with more than a dozen species. Feeding prebiotics will only mildly support Parabacteroides because other healthy bacteria compete for its fuel source.")]
    Parabacteroides = 1 << 9, // 2

    [Display(Name = "Roseburia", Description = "Roseburia is a butyrate-producing genus with several health-promoting species, most notably <em>Roseburia intestinalis</em>, <em>R. inulinivorans</em>, and <em>R. hominis</em>. The important species within this genus respond well to several different prebiotics and optimizing the presence of Roseburia species is your goal.")]
    Roseburia = 1 << 10, // 2

    [Display(Name = "Ruminococcus (- R bromii)", Description = "The large, health-promoting genus Ruminococcus responds mildly to several different prebiotics and is a genus you want to optimize because it is nearly universally positive.  <em>Ruminococcus bromii</em> is reported separately and has a positive role in supporting gastrointestinal motility.")]
    RuminococcusMinusRBromii = 1 << 11, // 2

    [Display(Name = "Ruminococcaceae", Description = "Ruminococcaceae is an important family within the phylum Firmicutes. It is synonymous with Clostridial Cluster IV, a grouping of bacteria considered widely beneficial for health. It contains important taxa for health, such as Oscillospira, Ruminococcus, and the significant <em>F. prausnitzii</em>. Considering these taxa at the family level gives a broader picture of this cluster, because each of the individual taxa can fluctuate. Higher levels are desirable.")]
    Ruminococcaceae = 1 << 12, // 2

    All = AkkermansiaMuciniphila | Alistipes | Bifidobacterium | Coprococcus | Eubacterium | EubacteriumRectale | FaecalibacteriumPrausnitzii
        | LachnospiraceaeMinusBlautia | Oscillospira | Parabacteroides | Roseburia | RuminococcusMinusRBromii | Ruminococcaceae,
}
