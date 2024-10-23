using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_fungi")]
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

    [Range(Consts.TotalFungiMin, Consts.TotalFungiMax)]
    [Display(Name = "Total Fungi")]
    public double? TotalFungi { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(TotalFungi), TotalFungi },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutFungi))]
    public virtual User User { get; set; } = null!;
}
