using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_conditional_bacteria"), Comment("User variation weight log")]
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

    [Range(0, 100)]
    [Display(Name = "Bacteroides")]
    public double? Bacteroides { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactobacillus")]
    public double? Lactobacillus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Methanobacteria")]
    public double? Methanobacteria { get; set; }

    [Range(0, 100)]
    [Display(Name = "Oscillibacter")]
    public double? Oscillibacter { get; set; }

    [Range(0, 100)]
    [Display(Name = "Prevotella")]
    public double? Prevotella { get; set; }

    [Range(0, 100)]
    [Display(Name = "Ruminococcus bromii")]
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
