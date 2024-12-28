using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_saliva_stress")]
public class UserSalivaStress
{
    public class Consts
    {
        public const double DHEAMin = 0;
        public const double DHEAMax = 1000;
        public const double DHEAStep = .1;

        public const double CortisolMin = 0;
        public const double CortisolMax = 100;
        public const double CortisolStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Display(Name = "Morning Cortisol")]
    [Range(Consts.CortisolMin, Consts.CortisolMax)]
    public double? MorningCortisol { get; set; }

    [Display(Name = "Daytime Cortisol")]
    [Range(Consts.CortisolMin, Consts.CortisolMax)]
    public double? DaytimeCortisol { get; set; }

    [Display(Name = "Evening Cortisol")]
    [Range(Consts.CortisolMin, Consts.CortisolMax)]
    public double? EveningCortisol { get; set; }

    [Display(Name = "Night Cortisol")]
    [Range(Consts.CortisolMin, Consts.CortisolMax)]
    public double? NightCortisol { get; set; }

    [Display(Name = "DHEA")]
    [Range(Consts.DHEAMin, Consts.DHEAMax)]
    public double? DHEA { get; set; }


    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(MorningCortisol), MorningCortisol },
        { nameof(DaytimeCortisol), DaytimeCortisol },
        { nameof(EveningCortisol), EveningCortisol },
        { nameof(NightCortisol), NightCortisol },
        { nameof(DHEA), DHEA },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSalivaStress))]
    public virtual User User { get; set; } = null!;
}
