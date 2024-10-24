using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_short_chain_fatty_acids")]
[Display(Name = "Short-Chain Fatty Acids", Description = "Short-chain fatty acids have numerous health benefits and are known to have anti-inflammatory effects, improve gut motility, reduce gut permeability, reduce intestinal lumen pH, and provide an important energy source.\r\nLactate is an example of a biochemical byproduct produced by various microbes that, in excess, can negatively impact your health. Lactate at low levels can be normal in healthy individuals and have no significant impact. Still, as lactate begins to accumulate, it can further drive inflammatory and disease processes and lead to further complications of various conditions.")]
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
    [Display(Name = "Butyrate", Description = "")]
    public double? Butyrate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Lactate", Description = "")]
    public double? Lactate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Propionate", Description = "")]
    public double? Propionate { get; set; }

    [Range(0, 100)]
    [Display(Name = "Valerate", Description = "")]
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
