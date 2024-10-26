using Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_bad_bacteria")]
[Display(Name = "Bad Bacteria", Description = "The Bad Bacteria below are well-researched and are associated with various health conditions adverse to your overall health. Your percentile is compared to healthy adults; the goal is to maintain a level that is below the 85th percentile for best health associations.")]
public class UserGutBadBacteria
{
    public class Consts
    {
        public const double BlautiaMin = 0;
        public const double BlautiaMax = 100;
        public const double BlautiaStep = .1;

        public const double CitrobacterFreundiiMin = 0;
        public const double CitrobacterFreundiiMax = 100;
        public const double CitrobacterFreundiiStep = .1;

        public const double ClostridioidesDifficileMin = 0;
        public const double ClostridioidesDifficileMax = 200;
        public const double ClostridioidesDifficileStep = .1;

        public const double EggerthellaMin = 0;
        public const double EggerthellaMax = 100;
        public const double EggerthellaStep = .1;

        public const double EggerthellaLentaMin = 0;
        public const double EggerthellaLentaMax = 100;
        public const double EggerthellaLentaStep = .1;

        public const double EnterobacteriaceaeMin = 0;
        public const double EnterobacteriaceaeMax = 100;
        public const double EnterobacteriaceaeStep = .1;

        public const double EnterobacteriaceaeAndPseudomonasMin = 0;
        public const double EnterobacteriaceaeAndPseudomonasMax = 100;
        public const double EnterobacteriaceaeAndPseudomonasStep = .1;

        public const double EnterococcusMin = 0;
        public const double EnterococcusMax = 100;
        public const double EnterococcusStep = .1;

        public const double EnterococcusFaecalisMin = 0;
        public const double EnterococcusFaecalisMax = 100;
        public const double EnterococcusFaecalisStep = .1;

        public const double EnterococcusFaeciumMin = 0;
        public const double EnterococcusFaeciumMax = 100;
        public const double EnterococcusFaeciumStep = .1;

        public const double EnterococcusFaecalisAndFaeciumMin = 0;
        public const double EnterococcusFaecalisAndFaeciumMax = 100;
        public const double EnterococcusFaecalisAndFaeciumStep = .1;

        public const double EscherichiaMin = 0;
        public const double EscherichiaMax = 100;
        public const double EscherichiaStep = .1;

        public const double EscherichiaColiMin = 0;
        public const double EscherichiaColiMax = 100;
        public const double EscherichiaColiStep = .1;

        public const double KlebsiellaMin = 0;
        public const double KlebsiellaMax = 100;
        public const double KlebsiellaStep = .1;

        public const double RuminococcusGnavusMin = 0;
        public const double RuminococcusGnavusMax = 100;
        public const double RuminococcusGnavusStep = .1;

        public const double RuminococcusTorquesMin = 0;
        public const double RuminococcusTorquesMax = 100;
        public const double RuminococcusTorquesStep = .1;

        public const double StaphylococcusMin = 0;
        public const double StaphylococcusMax = 100;
        public const double StaphylococcusStep = .1;

        public const double StaphylococcusAureusMin = 0;
        public const double StaphylococcusAureusMax = 100;
        public const double StaphylococcusAureusStep = .1;

        public const double StreptococcusMinusThermophilusAndSalivariusMin = 0;
        public const double StreptococcusMinusThermophilusAndSalivariusMax = 100;
        public const double StreptococcusMinusThermophilusAndSalivariusStep = .1;

        public const double VeillonellaMin = 0;
        public const double VeillonellaMax = 100;
        public const double VeillonellaStep = .1;

        public const double YersiniaEnterocoliticaMin = 0;
        public const double YersiniaEnterocoliticaMax = 100;
        public const double YersiniaEnterocoliticaStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.BlautiaMin, Consts.BlautiaMax)]
    [Display(Name = "Blautia", Description = "Blautia is a troublesome genus of importance linked to many health conditions. It should be considered a primary goal to reduce its levels.")]
    public double? Blautia { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.CitrobacterFreundiiMin, Consts.CitrobacterFreundiiMax)]
    [Display(Name = "Citrobacter freundii", Description = "<em>Citrobacter freundii</em> does not have numerous comparative data to healthy controls as other bacteria do. However, it is a well-known pathogen and a species of interest for health-care professionals. The species is commonly found in the human microbiome, although some rarer strains are problematic, producing Shiga toxins, heat-stable toxins, and cholera toxin homologs.")]
    public double? CitrobacterFreundii { get; set; }

    [IdealRange(0, 100, RiskType.LowRisk)]
    [IdealRange(100, 200, RiskType.HighRisk)]
    [Range(Consts.ClostridioidesDifficileMin, Consts.ClostridioidesDifficileMax)]
    [Display(Name = "Clostridioides difficile", Description = "<em>Clostridiodes difficile</em>, previously <em>Clostridium difficile</em>, is commonly referred to as C. diff. It is widely present and detected in almost 100 percent of gut microbiomes. The primary cause of a C. diff infection is excessive antibiotic use. When the environment of the gut is altered, more antibiotic-resistant bad bacteria can thrive and cause problems. When high, your goal is to reduce its count.")]
    public double? ClostridioidesDifficile { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EggerthellaMin, Consts.EggerthellaMax)]
    [Display(Name = "Eggerthella", Description = "Eggerthella is a modest-sized genus of various troublesome species. It's classified in the phylum Actinobacteria, along with Bifidobacterium, and suggests that high levels of Actinobacteria are not always beneficial. When high, your goal is to reduce its levels.")]
    public double? Eggerthella { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EggerthellaLentaMin, Consts.EggerthellaLentaMax)]
    [Display(Name = "Eggerthella lenta", Description = "<em>Eggerthella lenta</em> is the most reported species within the genus Eggerthella. Most individuals have measurable levels, and when found to be elevated, your goal is to lower it.")]
    public double? EggerthellaLenta { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterobacteriaceaeMin, Consts.EnterobacteriaceaeMax)]
    [Display(Name = "Enterobacteriaceae", Description = "Enterobacteriaceae is a family of pathogenic members that include the genera Escherichia (which includes <em>E. coli</em>), Salmonella, Shigella, and Klebsiella. Enterobacteriaceae are negatively associated with every health condition to date. When your levels are high, reducing them is a priority.")]
    public double? Enterobacteriaceae { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterobacteriaceaeAndPseudomonasMin, Consts.EnterobacteriaceaeAndPseudomonasMax)]
    [Display(Name = "Enterobacteriaceae + Pseudomonas", Description = "A number of different bacteria contain the immunostimulatory LPS found in gram-negative bacteria. But not all are created equal. Data shows that LPS from certain taxa are 100 to 1,000 times more immunostimulatory than others. We’ve included the genus Pseudomonas separately here, added to the highly problematic family Enterobacteriaceae, as significant contributors to LPS-driven inflammation.")]
    public double? EnterobacteriaceaeAndPseudomonas { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterococcusMin, Consts.EnterococcusMax)]
    [Display(Name = "Enterococcus", Description = "Enterococcus is a large genus of bacteria, with two of its species, <em>E. faecalis</em> and <em>E. faecium</em>, most commonly found in gut-microbiome research. When found to be high, your goal is to reduce its level.")]
    public double? Enterococcus { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterococcusFaecalisMin, Consts.EnterococcusFaecalisMax)]
    [Display(Name = "Enterococcus faecalis", Description = "Enterococcus faecalis is a troublesome species within the pathogenic genus Enterococcus. <em>E. faecalis</em> is detectable in nearly all healthy people at varying levels, and when elevated, your goal is to reduce its level.")]
    public double? EnterococcusFaecalis { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterococcusFaeciumMin, Consts.EnterococcusFaeciumMax)]
    [Display(Name = "Enterococcus faecium", Description = "Enterococcus faecium is a troublesome species within the pathogenic genus Enterococcus. Recent research has found, like <em>E. faecalis</em>, <em>E. faecium</em> converts the Parkinson's drug L-Dopa into dopamine, thereby causing GI side effects and limiting L-Dopa serum availability for the brain. <em>E. faecium</em> is also detectable in essentially all healthy individuals at varying levels, and when elevated, the goal is to reduce its level.")]
    public double? EnterococcusFaecium { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EnterococcusFaecalisAndFaeciumMin, Consts.EnterococcusFaecalisAndFaeciumMax)]
    [Display(Name = "Enterococcus faecalis + faecium", Description = "These two troublesome species are combined and compared to healthy controls. The genus Enterococcus is full of virulence factors, and these two species consist of common inhabitants of the human microbiome. When given the right environment, they can thrive and become pathogenic. This combination allows us to analyze these two species independently from the large Enterococcus genus.")]
    public double? EnterococcusFaecalisAndFaecium { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EscherichiaMin, Consts.EscherichiaMax)]
    [Display(Name = "Escherichia", Description = "Escherichia is a modest-sized genus in the highly troublesome family Enterobacteriaceae. Its most well-known species is <em>Escherichia coli</em>. When found to be high, your goal is to reduce it.")]
    public double? Escherichia { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.EscherichiaColiMin, Consts.EscherichiaColiMax)]
    [Display(Name = "Escherichia coli", Description = "E. coli is a classic opportunistic pathogen. E. coli is often reported with food recalls, which is likely the strain <em>E. coli O157:H7</em>, although there are many different strains within this species. E. coli is present in all human guts and most strains are harmless, but some can be troublesome when allowed to thrive. Your goal is to reduce the level of E. coli.")]
    public double? EscherichiaColi { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.KlebsiellaMin, Consts.KlebsiellaMax)]
    [Display(Name = "Klebsiella", Description = "The large genus Klebsiella resides in the highly troublesome family Enterobacteriaceae. Its most well-known species, <em>K. pneumoniae</em>, is responsible for many human infections outside the GI tract. If found to be high, then your goal is to reduce its level.")]
    public double? Klebsiella { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.RuminococcusGnavusMin, Consts.RuminococcusGnavusMax)]
    [Display(Name = "Ruminococcus gnavus", Description = "<em>R. gnavus</em> has been once again reclassified, this time into the genus Mediterraneibacter. <em>R. gnavus</em> has negative data in a number of conditions, most notably in irritable bowel syndrome (IBS). Most healthy people have very low levels, but when found to be elevated, the goal is to reduce the levels of this pro-inflammatory, mucin-degrading species.")]
    public double? RuminococcusGnavus { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.RuminococcusTorquesMin, Consts.RuminococcusTorquesMax)]
    [Display(Name = "Ruminococcus torques", Description = "<em>R. torques</em> has been once again reclassified, this time into the genus Mediterraneibacter. <em>R. torques</em> has negative data in a few of conditions, most notably in gut-specific ones. <em>R. torques</em> is a very prevalent species, and when found to be elevated, the goal is to reduce the levels of this mucin-degrading species.")]
    public double? RuminococcusTorques { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.StaphylococcusMin, Consts.StaphylococcusMax)]
    [Display(Name = "Staphylococcus", Description = "Staphylococcus is a genus of potential troublemakers. Its species are known to cause infections throughout the body. This genus is the namesake for the term &quot;staph infection,&quot; and its most troublesome species, <em>S. aureus</em>, causes MRSA in its antibiotic-resistant form. Most healthy individuals have low levels in their microbiome.")]
    public double? Staphylococcus { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.StaphylococcusAureusMin, Consts.StaphylococcusAureusMax)]
    [Display(Name = "Staphylococcus aureus", Description = "<em>S. aureus</em> is the most troublesome species in the genus Staphylococcus. Its antibiotic-resistant form is where we get the term MRSA from. Most healthy individuals have low levels in their microbiome.")]
    public double? StaphylococcusAureus { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.StreptococcusMinusThermophilusAndSalivariusMin, Consts.StreptococcusMinusThermophilusAndSalivariusMax)]
    [Display(Name = "Streptococcus (- thermophilus and salivarius)", Description = "The large genus Streptococcus is the source of conditions like &quot;strep throat&quot; and flesh-eating bacteria. But like many genera, not all species within this group are bad. <em>S. thermophilus</em> and <em>S. salivarius</em> are &quot;good&quot; bacteria, often found in probiotic blends, although their data is not always associated with health. Minus the two species <em>S. thermophilus</em> and <em>S. salivarius</em>, the rest of the Streptococcus genus is undesirable, and when found to be high, your goal is to reduce its level.")]
    public double? StreptococcusMinusThermophilusAndSalivarius { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.VeillonellaMin, Consts.VeillonellaMax)]
    [Display(Name = "Veillonella", Description = "Veillonella is a modest-sized genus of potentially bad microbes. When found to be elevated compared to healthy controls, your goal is to reduce their levels.")]
    public double? Veillonella { get; set; }

    [IdealRange(0, 33, RiskType.LowRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.HighRisk)]
    [Range(Consts.YersiniaEnterocoliticaMin, Consts.YersiniaEnterocoliticaMax)]
    [Display(Name = "Yersinia enterocolitica", Description = "<em>Yersinia enterocolitica</em> is a well-known pathogen and a species of interest for health-care professionals. The primary route of <em>Y. enterocolitica</em> infection is through contaminated food or water, resulting in gastrointestinal infections. Note: this is reported at the species level and does not report specific strains.")]
    public double? YersiniaEnterocolitica { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Blautia), Blautia },
        { nameof(CitrobacterFreundii), CitrobacterFreundii },
        { nameof(ClostridioidesDifficile), ClostridioidesDifficile },
        { nameof(Eggerthella), Eggerthella },
        { nameof(EggerthellaLenta), EggerthellaLenta },
        { nameof(Enterobacteriaceae), Enterobacteriaceae },
        { nameof(EnterobacteriaceaeAndPseudomonas), EnterobacteriaceaeAndPseudomonas },
        { nameof(Enterococcus), Enterococcus },
        { nameof(EnterococcusFaecalis), EnterococcusFaecalis },
        { nameof(EnterococcusFaecium), EnterococcusFaecium },
        { nameof(EnterococcusFaecalisAndFaecium), EnterococcusFaecalisAndFaecium },
        { nameof(Escherichia), Escherichia },
        { nameof(EscherichiaColi), EscherichiaColi },
        { nameof(Klebsiella), Klebsiella },
        { nameof(RuminococcusGnavus), RuminococcusGnavus },
        { nameof(RuminococcusTorques), RuminococcusTorques },
        { nameof(Staphylococcus), Staphylococcus },
        { nameof(StaphylococcusAureus), StaphylococcusAureus },
        { nameof(StreptococcusMinusThermophilusAndSalivarius), StreptococcusMinusThermophilusAndSalivarius },
        { nameof(Veillonella), Veillonella },
        { nameof(YersiniaEnterocolitica), YersiniaEnterocolitica },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutBadBacteria))]
    public virtual User User { get; set; } = null!;
}
