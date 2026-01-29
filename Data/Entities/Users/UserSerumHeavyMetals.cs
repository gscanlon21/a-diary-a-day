using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_heavy_metals")]
public class UserSerumHeavyMetals
{
    public class Consts
    {
        public const double LeadMin = 0;
        public const double LeadMax = 10;
        public const double LeadStep = .5;

        public const int MercuryMin = 0;
        public const int MercuryMax = 100;
        public const int MercuryStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.LeadMin, Consts.LeadMax)]
    [Display(Name = "Lead")]
    public double? Lead { get; set; }

    [Range(Consts.MercuryMin, Consts.MercuryMax)]
    [Display(Name = "Mercury")]
    public int? Mercury { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Lead), Lead },
        { nameof(Mercury), Mercury },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumHeavyMetals))]
    public virtual User User { get; set; } = null!;
}
