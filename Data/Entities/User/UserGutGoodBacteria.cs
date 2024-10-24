using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_good_bacteria"), Comment("User variation weight log")]
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

    [Range(0, 100)]
    [Display(Name = "Akkermansia muciniphila")]
    public double? AkkermansiaMuciniphila { get; set; }

    [Range(0, 100)]
    [Display(Name = "Alistipes")]
    public double? Alistipes { get; set; }

    [Range(0, 100)]
    [Display(Name = "Bifidobacterium")]
    public double? Bifidobacterium { get; set; }

    [Range(0, 100)]
    [Display(Name = "Coprococcus")]
    public double? Coprococcus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Eubacterium")]
    public double? Eubacterium { get; set; }

    [Range(0, 100)]
    [Display(Name = "Eubacterium rectale")]
    public double? EubacteriumRectale { get; set; }

    [Range(0, 100)]
    [Display(Name = "Faecalibacterium prausnitzii")]
    public double? FaecalibacteriumPrausnitzii { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lachnospiraceae (- Blautia)")]
    public double? LachnospiraceaeMinusBlautia { get; set; }

    [Range(0, 100)]
    [Display(Name = "Oscillospira")]
    public double? Oscillospira { get; set; }

    [Range(0, 100)]
    [Display(Name = "Parabacteroides")]
    public double? Parabacteroides { get; set; }

    [Range(0, 100)]
    [Display(Name = "Roseburia")]
    public double? Roseburia { get; set; }

    [Range(0, 100)]
    [Display(Name = "Ruminococcus (- R bromii)")]
    public double? RuminococcusMinusRBromii { get; set; }

    [Range(0, 100)]
    [Display(Name = "Ruminococcaceae")]
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

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutGoodBacteria))]
    public virtual User User { get; set; } = null!;
}
