using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_probiotics"), Comment("User variation weight log")]
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

    [Range(0, 100)]
    [Display(Name = "Bacillus coagulans")]
    public double? BacillusCoagulans { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium animalis subsp. animalis")]
    public double? BifidobacteriumAnimalisSubspAnimalis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium animalis subsp. lactis")]
    public double? BifidobacteriumAnimalisSubspLactis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium bifidum")]
    public double? BifidobacteriumBifidum { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium breve")]
    public double? BifidobacteriumBreve { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium longum subsp. infantis")]
    public double? BifidobacteriumLongumSubspInfantis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium longum subsp. longum")]
    public double? BifidobacteriumLongumSubspLongum { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus acidophilus")]
    public double? LactobacillusAcidophilus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus brevis")]
    public double? LactobacillusBrevis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus casei")]
    public double? LactobacillusCasei { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus delbrueckii subsp. bulgaricus")]
    public double? LactobacillusDelbrueckiiSubspBulgaricus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus delbrueckii subsp. delbrueckii")]
    public double? LactobacillusDelbrueckiiSubspDelbrueckii { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus fermentum")]
    public double? LactobacillusFermentum { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus gasseri")]
    public double? LactobacillusGasseri { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus helveticus")]
    public double? LactobacillusHelveticus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus paracasei")]
    public double? LactobacillusParacasei { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus plantarum")]
    public double? LactobacillusPlantarum { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus reuteri")]
    public double? LactobacillusReuteri { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus rhamnosus")]
    public double? LactobacillusRhamnosus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus salivarius")]
    public double? LactobacillusSalivarius { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactococcus lactis")]
    public double? LactococcusLactis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Propionibacterium freudenreichii")]
    public double? PropionibacteriumFreudenreichii { get; set; }

    [Range(0, 100)]
    [Display(Name = "Streptococcus salivarius")]
    public double? StreptococcusSalivarius { get; set; }

    [Range(0, 100)]
    [Display(Name = "Streptococcus thermophilus")]
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

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutProbiotics))]
    public virtual User User { get; set; } = null!;
}
