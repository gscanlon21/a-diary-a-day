using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_probiotics")]
[Display(Name = "Probiotics", Description = "The list of probiotics below includes the majority of commercially available strains and provides insight into which are present or missing from your gut. Also, use this list to check that your current prebiotic or probiotic supplement regimen is working for you by supporting the strains you are now consuming. Your goal is to maximize the presence of species you have present because they have many associated health benefits. It is important to note that not all of these probiotic strains are commercially available as supplements, although luckily, many can be increased in the gut through precise prebiotic regimens.")]
public class UserGutProbiotics
{
    public class Consts
    {
        public const double BacillusCoagulansMin = 0;
        public const double BacillusCoagulansMax = 100;
        public const double BacillusCoagulansStep = .1;

        public const double BifidobacteriumAnimalisSubspAnimalisMin = 0;
        public const double BifidobacteriumAnimalisSubspAnimalisMax = 100;
        public const double BifidobacteriumAnimalisSubspAnimalisStep = .1;

        public const double BifidobacteriumAnimalisSubspLactisMin = 0;
        public const double BifidobacteriumAnimalisSubspLactisMax = 100;
        public const double BifidobacteriumAnimalisSubspLactisStep = .1;

        public const double BifidobacteriumBifidumMin = 0;
        public const double BifidobacteriumBifidumMax = 100;
        public const double BifidobacteriumBifidumStep = .1;

        public const double BifidobacteriumBreveMin = 0;
        public const double BifidobacteriumBreveMax = 100;
        public const double BifidobacteriumBreveStep = .1;

        public const double BifidobacteriumLongumSubspInfantisMin = 0;
        public const double BifidobacteriumLongumSubspInfantisMax = 100;
        public const double BifidobacteriumLongumSubspInfantisStep = .1;

        public const double BifidobacteriumLongumSubspLongumMin = 0;
        public const double BifidobacteriumLongumSubspLongumMax = 100;
        public const double BifidobacteriumLongumSubspLongumStep = .1;

        public const double LactobacillusAcidophilusMin = 0;
        public const double LactobacillusAcidophilusMax = 100;
        public const double LactobacillusAcidophilusStep = .1;

        public const double LactobacillusBrevisMin = 0;
        public const double LactobacillusBrevisMax = 100;
        public const double LactobacillusBrevisStep = .1;

        public const double PlatletCountMin = 0;
        public const double PlatletCountMax = 100;
        public const double PlatletCountStep = .1;

        public const double LactobacillusCaseiMin = 0;
        public const double LactobacillusCaseiMax = 100;
        public const double LactobacillusCaseiStep = .1;

        public const double LactobacillusDelbrueckiiSubspBulgaricusMin = 0;
        public const double LactobacillusDelbrueckiiSubspBulgaricusMax = 100;
        public const double LactobacillusDelbrueckiiSubspBulgaricusStep = .1;

        public const double LactobacillusDelbrueckiiSubspDelbrueckiiMin = 0;
        public const double LactobacillusDelbrueckiiSubspDelbrueckiiMax = 100;
        public const double LactobacillusDelbrueckiiSubspDelbrueckiiStep = .1;

        public const double LactobacillusFermentumMin = 0;
        public const double LactobacillusFermentumMax = 100;
        public const double LactobacillusFermentumStep = .1;

        public const double LactobacillusGasseriMin = 0;
        public const double LactobacillusGasseriMax = 100;
        public const double LactobacillusGasseriStep = .1;

        public const double LactobacillusHelveticusMin = 0;
        public const double LactobacillusHelveticusMax = 100;
        public const double LactobacillusHelveticusStep = .1;

        public const double LactobacillusParacaseiMin = 0;
        public const double LactobacillusParacaseiMax = 100;
        public const double LactobacillusParacaseiStep = .1;

        public const double LactobacillusPlantarumMin = 0;
        public const double LactobacillusPlantarumMax = 100;
        public const double LactobacillusPlantarumStep = .1;

        public const double LactobacillusReuteriMin = 0;
        public const double LactobacillusReuteriMax = 100;
        public const double LactobacillusReuteriStep = .1;

        public const double LactobacillusSalivariusMin = 0;
        public const double LactobacillusSalivariusMax = 100;
        public const double LactobacillusSalivariusStep = .1;

        public const double LactobacillusRhamnosusMin = 0;
        public const double LactobacillusRhamnosusMax = 100;
        public const double LactobacillusRhamnosusStep = .1;

        public const double LactococcusLactisMin = 0;
        public const double LactococcusLactisMax = 100;
        public const double LactococcusLactisStep = .1;

        public const double PropionibacteriumFreudenreichiiMin = 0;
        public const double PropionibacteriumFreudenreichiiMax = 100;
        public const double PropionibacteriumFreudenreichiiStep = .1;

        public const double StreptococcusSalivariusMin = 0;
        public const double StreptococcusSalivariusMax = 100;
        public const double StreptococcusSalivariusStep = .1;

        public const double StreptococcusThermophilusMin = 0;
        public const double StreptococcusThermophilusMax = 100;
        public const double StreptococcusThermophilusStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.BacillusCoagulansMin, Consts.BacillusCoagulansMax)]
    [Display(Name = "Bacillus coagulans", Description = "Although <em>B. coagulans</em> is known as a beneficial spore-forming commercial probiotic, it does not occupy much space in the gut. About 97.5% of healthy controls from our database have detectable levels in fecal samples. The detectable levels are quite low, and at most, occupy 0.01% of the microbiome.")]
    public double? BacillusCoagulans { get; set; }

    [Range(Consts.BifidobacteriumAnimalisSubspAnimalisMin, Consts.BifidobacteriumAnimalisSubspAnimalisMax)]
    [Display(Name = "Bifidobacterium animalis subsp. animalis", Description = "<em>B. animalis</em> is relatively common in the human microbiome. About 67.5% of healthy controls from our database have detectable levels in their fecal sample, so it not surprising if you have it too. Levels are very low; it takes up about 0.001% of the total microbiome.")]
    public double? BifidobacteriumAnimalisSubspAnimalis { get; set; }

    [Range(Consts.BifidobacteriumAnimalisSubspLactisMin, Consts.BifidobacteriumAnimalisSubspLactisMax)]
    [Display(Name = "Bifidobacterium animalis subsp. lactis", Description = "<em>B. lactis</em> is common in the human microbiome. About 74.5% of healthy controls from our database have detectable levels in their fecal sample, so it not surprising if you have it too. Levels are very low; it takes up about 0.003% of the total microbiome.")]
    public double? BifidobacteriumAnimalisSubspLactis { get; set; }

    [Range(Consts.BifidobacteriumBifidumMin, Consts.BifidobacteriumBifidumMax)]
    [Display(Name = "Bifidobacterium bifidum", Description = "<em>B. bifidum</em> is a very common occupant of the human microbiome. Just about 100% of healthy controls from our database have detectable levels in their fecal sample. Its levels are modest, and it occupies about 1% of the total microbiome. It ranges in healthy controls from 0.5% to 6% of the entire microbiome. Although it seems like a large amount, its average abundance does not make it one of the top 50 most prevalent species.")]
    public double? BifidobacteriumBifidum { get; set; }

    [Range(Consts.BifidobacteriumBreveMin, Consts.BifidobacteriumBreveMax)]
    [Display(Name = "Bifidobacterium breve", Description = "<em>B. breve</em> is a very common occupant of the human microbiome. Nearly 100% of healthy controls from our database have detectable levels in their fecal sample. Its levels are modest, averaging about 1% of the total microbiome, but can range in healthy controls from 0.2% to 1.8% of the space. This prevalence rate does not make B. breve one of the 50 most abundant species in the gut microbiome.")]
    public double? BifidobacteriumBreve { get; set; }

    [Range(Consts.BifidobacteriumLongumSubspInfantisMin, Consts.BifidobacteriumLongumSubspInfantisMax)]
    [Display(Name = "Bifidobacterium longum subsp. infantis", Description = "<em>B. infantis</em> is a very common member of the human microbiome. Nearly 100% of healthy controls from our database have detectable levels in their fecal sample. Its levels are modest, occupying about 0.08% of the total microbiome, but some healthy adults can be around 0.6%. Its mean abundance does not qualify it to be in the top 50 species found in the human gut.")]
    public double? BifidobacteriumLongumSubspInfantis { get; set; }

    [Range(Consts.BifidobacteriumLongumSubspLongumMin, Consts.BifidobacteriumLongumSubspLongumMax)]
    [Display(Name = "Bifidobacterium longum subsp. longum", Description = "<em>B. longum</em> is a very common member of the human microbiome. Nearly 100% of healthy controls from our database have detectable levels in their fecal sample. Its levels are modest, occupying about 0.14% of the total microbiome.")]
    public double? BifidobacteriumLongumSubspLongum { get; set; }

    [Range(Consts.LactobacillusAcidophilusMin, Consts.LactobacillusAcidophilusMax)]
    [Display(Name = "Lactobacillus acidophilus", Description = "<em>L. acidophilus</em> is one of the most consumed probiotics, yet 68.4% of healthy controls from our database do not have detectable levels. Therefore, do not be surprised if you do not have detectable levels. When present, its levels are low, occupying about 0.06% of the total microbiome.")]
    public double? LactobacillusAcidophilus { get; set; }

    [Range(Consts.LactobacillusBrevisMin, Consts.LactobacillusBrevisMax)]
    [Display(Name = "Lactobacillus brevis", Description = "<em>L brevis</em> has recently been reclassified to <em>Levilactobacillus brevis</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. brevis</em> is a relatively uncommon member of the human microbiome. Only about 21.6% of healthy controls from our database have detectable levels. Amounts are small, occupying about 0.0004% of the total microbiome.")]
    public double? LactobacillusBrevis { get; set; }

    [Range(Consts.LactobacillusCaseiMin, Consts.LactobacillusCaseiMax)]
    [Display(Name = "Lactobacillus casei", Description = "<em>L casei</em> has recently been reclassified to <em>Lacticaseibacillus casei</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. casei</em> is a relatively common member of the human microbiome. About 63.6% of healthy controls from our database have detectable levels. Its levels are very low, occupying about 0.002% of the total microbiome.")]
    public double? LactobacillusCasei { get; set; }

    [Range(Consts.LactobacillusDelbrueckiiSubspBulgaricusMin, Consts.LactobacillusDelbrueckiiSubspBulgaricusMax)]
    [Display(Name = "Lactobacillus delbrueckii subsp. bulgaricus", Description = "<em>L. bulgaricus</em> is a relatively uncommon member of the human microbiome. Only about 21.8% of healthy controls from our large database have detectable levels. Its levels are small, occupying about 0.001 to 1% of the total microbiome.")]
    public double? LactobacillusDelbrueckiiSubspBulgaricus { get; set; }

    [Range(Consts.LactobacillusDelbrueckiiSubspDelbrueckiiMin, Consts.LactobacillusDelbrueckiiSubspDelbrueckiiMax)]
    [Display(Name = "Lactobacillus delbrueckii subsp. delbrueckii", Description = "<em>L. delbrueckii</em> is a rare occupant of the human microbiome. Only 1.8% of healthy controls from our database have detectable levels. You will likely not have levels unless you are taking a supplement that contains viable counts of this species. Its levels are low, measuring about 0.0002% of the total microbiome.")]
    public double? LactobacillusDelbrueckiiSubspDelbrueckii { get; set; }

    [Range(Consts.LactobacillusFermentumMin, Consts.LactobacillusFermentumMax)]
    [Display(Name = "Lactobacillus fermentum", Description = "<em>L. fermentum</em> has recently been reclassified to <em>Limosilactobacillus fermentum</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. fermentum</em> is a relatively common member of the human microbiome. About 60.3% of healthy controls from our database have detectable levels in their fecal sample. Its levels are very low, averaging 0.008% of the total microbiome.")]
    public double? LactobacillusFermentum { get; set; }

    [Range(Consts.LactobacillusGasseriMin, Consts.LactobacillusGasseriMax)]
    [Display(Name = "Lactobacillus gasseri", Description = "<em>L. gasseri</em> is a relatively uncommon member of the human microbiome. Only about 27.2% of healthy controls from our database have detectable levels. Its levels are very low, averaging 0.003% of the total microbiome.")]
    public double? LactobacillusGasseri { get; set; }

    [Range(Consts.LactobacillusHelveticusMin, Consts.LactobacillusHelveticusMax)]
    [Display(Name = "Lactobacillus helveticus", Description = "<em>L. helviticus</em> is a relatively uncommon member of the human microbiome. Only about 26.6% of healthy controls from our database have detectable levels. Its levels are very low, averaging 0.001% of the total microbiome.")]
    public double? LactobacillusHelveticus { get; set; }

    [Range(Consts.LactobacillusParacaseiMin, Consts.LactobacillusParacaseiMax)]
    [Display(Name = "Lactobacillus paracasei", Description = "<em>L. paracasei</em> has recently been reclassified to <em>Lacticaseibacillus paracasei</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. paracasei</em> is a relatively common member of the human microbiome. Around 63.7% of healthy controls from our database have detectable levels. Its levels are low, averaging 0.04% of the total microbiome.")]
    public double? LactobacillusParacasei { get; set; }

    [Range(Consts.LactobacillusPlantarumMin, Consts.LactobacillusPlantarumMax)]
    [Display(Name = "Lactobacillus plantarum", Description = "<em>L. plantarum</em> has recently been reclassified to <em>Lactiplantibacillus plantarum</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. plantarum</em> is a relatively common member of the human microbiome. Around 62.7% of healthy controls from our database have detectable levels in their fecal sample. Its levels are low, averaging 0.02% of the total microbiome when excluding 0.5% of healthy outliers.")]
    public double? LactobacillusPlantarum { get; set; }

    [Range(Consts.LactobacillusReuteriMin, Consts.LactobacillusReuteriMax)]
    [Display(Name = "Lactobacillus reuteri", Description = "<em>L. reuteri</em> has recently been reclassified to <em>Limosilactobacillus reuteri</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. reuteri</em> is just about average in rates of occurrence in the microbiome. About 47.2% of healthy controls from our database have detectable levels. The chances are higher it will be in your sample if you are taking a viable probiotic of this species. Its occupancy levels are low at 0.009% of the total microbiome when excluding 0.5% of healthy outliers.")]
    public double? LactobacillusReuteri { get; set; }

    [Range(Consts.LactobacillusRhamnosusMin, Consts.LactobacillusRhamnosusMax)]
    [Display(Name = "Lactobacillus rhamnosus", Description = "<em>L. rhamnosus</em> has recently been reclassified to <em>Lacticaseibacillus rhamnosus</em, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. rhamnosus</em> is a relatively common member of the human microbiome. About 62.4% of healthy controls from our database have detectable levels, but levels are low at 0.05% of the total microbiome.")]
    public double? LactobacillusRhamnosus { get; set; }

    [Range(Consts.LactobacillusSalivariusMin, Consts.LactobacillusSalivariusMax)]
    [Display(Name = "Lactobacillus salivarius", Description = "<em>L. salivarius</em> has recently been reclassified to <em>Ligilactobacillus salivarius</em>, but to reduce confusion, we’ll continue to use its former name for our purposes. <em>L. salivarius</em> is a very common member of the human microbiome. About 97% of healthy controls from our database have detectable levels, but levels are only 0.003% of the total microbiome.")]
    public double? LactobacillusSalivarius { get; set; }

    [Range(Consts.LactococcusLactisMin, Consts.LactococcusLactisMax)]
    [Display(Name = "Lactococcus lactis", Description = "<em>L. lactis</em> is a common member of the human microbiome. Nearly 100% of healthy controls from our database have detectable levels. It is found in small amounts, occupying about 0.08% of the total microbiome. Although common, its mean abundance does not bring it into the top 50 species.")]
    public double? LactococcusLactis { get; set; }

    [Range(Consts.PropionibacteriumFreudenreichiiMin, Consts.PropionibacteriumFreudenreichiiMax)]
    [Display(Name = "Propionibacterium freudenreichii", Description = "Although <em>P. freudenreichii</em> is not a very popular commercial probiotic, it is commonly found inside our microbiome, as 94.5% of healthy controls from our database have detectable levels. However, it only accounts for about 0.02% of the microbiome.")]
    public double? PropionibacteriumFreudenreichii { get; set; }

    [Range(Consts.StreptococcusSalivariusMin, Consts.StreptococcusSalivariusMax)]
    [Display(Name = "Streptococcus salivarius", Description = "<em>S. salivarius</em> is found in nearly 100% of healthy controls from our database. Its levels are modest, accounting for about 1% of the total microbiome. Although 1% may sound high, this is its peak, as its mean abundance does not bring it into the top 50 species present in the microbiome.")]
    public double? StreptococcusSalivarius { get; set; }

    [Range(Consts.StreptococcusThermophilusMin, Consts.StreptococcusThermophilusMax)]
    [Display(Name = "Streptococcus thermophilus", Description = "<em>S. thermophilus</em> is found in nearly all healthy controls from our database. Its levels are modest at 1.76% of the total microbiome, and this lower abundance does not warrant it being in the top 50 species present in the microbiome.")]
    public double? StreptococcusThermophilus { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(BacillusCoagulans), BacillusCoagulans },
        { nameof(BifidobacteriumAnimalisSubspAnimalis), BifidobacteriumAnimalisSubspAnimalis },
        { nameof(BifidobacteriumAnimalisSubspLactis), BifidobacteriumAnimalisSubspLactis },
        { nameof(BifidobacteriumBifidum), BifidobacteriumBifidum },
        { nameof(BifidobacteriumBreve), BifidobacteriumBreve },
        { nameof(BifidobacteriumLongumSubspInfantis), BifidobacteriumLongumSubspInfantis },
        { nameof(BifidobacteriumLongumSubspLongum), BifidobacteriumLongumSubspLongum },
        { nameof(LactobacillusAcidophilus), LactobacillusAcidophilus },
        { nameof(LactobacillusBrevis), LactobacillusBrevis },
        { nameof(LactobacillusCasei), LactobacillusCasei },
        { nameof(LactobacillusDelbrueckiiSubspBulgaricus), LactobacillusDelbrueckiiSubspBulgaricus },
        { nameof(LactobacillusDelbrueckiiSubspDelbrueckii), LactobacillusDelbrueckiiSubspDelbrueckii },
        { nameof(LactobacillusFermentum), LactobacillusFermentum },
        { nameof(LactobacillusGasseri), LactobacillusGasseri },
        { nameof(LactobacillusHelveticus), LactobacillusHelveticus },
        { nameof(LactobacillusParacasei), LactobacillusParacasei },
        { nameof(LactobacillusPlantarum), LactobacillusPlantarum },
        { nameof(LactobacillusReuteri), LactobacillusReuteri },
        { nameof(LactobacillusRhamnosus), LactobacillusRhamnosus },
        { nameof(LactobacillusSalivarius), LactobacillusSalivarius },
        { nameof(LactococcusLactis), LactococcusLactis },
        { nameof(PropionibacteriumFreudenreichii), PropionibacteriumFreudenreichii },
        { nameof(StreptococcusSalivarius), StreptococcusSalivarius },
        { nameof(StreptococcusThermophilus), StreptococcusThermophilus },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserGutProbiotics))]
    public virtual User User { get; set; } = null!;
}
