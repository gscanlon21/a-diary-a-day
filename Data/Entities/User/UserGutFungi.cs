using Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_fungi")]
[Display(Name = "Total Fungi", Description = "Your Total Fungi score is a percentile rank comparing the total fungi ‐ both good and bad ‐ in your sample to samples of healthy adults. A low score is desirable.")]
public class UserGutFungi
{
    public class Consts
    {
        public const double TotalFungiMin = 0;
        public const double TotalFungiMax = 150;
        public const double TotalFungiStep = .1;
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
    [Range(Consts.TotalFungiMin, Consts.TotalFungiMax)]
    [Display(Name = "Total Fungi", Description = "Your Total Fungi score is a percentile rank comparing the total fungi ‐ both good and bad ‐ in your sample to samples of healthy adults. A low score is desirable.")]
    public double? TotalFungi { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(TotalFungi), TotalFungi },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutFungi))]
    public virtual User User { get; set; } = null!;
}
