using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_short_chain_fatty_acids"), Comment("User variation weight log")]
public class UserGutShortChainFattyAcids
{
    public class Consts
    {
        public const double ButyrateMin = 0;
        public const double ButyrateMax = 100;
        public const double ButyrateStep = .1;

        public const double LactateMin = 0;
        public const double LactateMax = 100;
        public const double LactateStep = .1;

        public const double PropionateMin = 0;
        public const double PropionateMax = 100;
        public const double PropionateStep = .1;

        public const double ValerateMin = 0;
        public const double ValerateMax = 100;
        public const double ValerateStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 100)]
    [Display(Name = "Butyrate")]
    public double? Butyrate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactate")]
    public double? Lactate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Propionate")]
    public double? Propionate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Valerate")]
    public double? Valerate { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Butyrate), Butyrate },
        { nameof(Lactate), Lactate },
        { nameof(Propionate), Propionate },
        { nameof(Valerate), Valerate },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutShortChainFattyAcids))]
    public virtual User User { get; set; } = null!;
}
