using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_fungi"), Comment("User variation weight log")]
public class UserGutFungi
{
    public class Consts
    {
        public const double PlatletCountMin = 100;
        public const double PlatletCountMax = 500;
        public const double PlatletCountStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(40, 240)]
    [Display(Name = "Total Fungi")]
    public int? TotalFungi { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(TotalFungi), TotalFungi },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutFungi))]
    public virtual User User { get; set; } = null!;
}
