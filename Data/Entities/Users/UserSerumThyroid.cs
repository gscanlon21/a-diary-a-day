using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_thyroid")]
public class UserSerumThyroid
{
    public class Consts
    {
        public const double TgAbMin = 1;
        public const double TgAbMax = 1000;
        public const double TgAbStep = .1;

        public const double TPOMin = 1;
        public const double TPOMax = 1000;
        public const double TPOStep = .1;

        public const double TSHMin = 1;
        public const double TSHMax = 1000;
        public const double TSHStep = .1;

        public const double T4Min = 1;
        public const double T4Max = 1000;
        public const double T4Step = .1;

        public const double T3Min = 1;
        public const double T3Max = 1000;
        public const double T3Step = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.TgAbMin, Consts.TgAbMax)]
    [Display(Name = "TgAb")]
    public double? TgAb { get; set; }

    [Range(Consts.TPOMin, Consts.TPOMax)]
    [Display(Name = "TPO")]
    public double? TPO { get; set; }

    [Range(Consts.TSHMin, Consts.TSHMax)]
    [Display(Name = "TSH")]
    public double? TSH { get; set; }

    [Range(Consts.T4Min, Consts.T4Max)]
    [Display(Name = "T4")]
    public double? T4 { get; set; }

    [Range(Consts.T3Min, Consts.T3Max)]
    [Display(Name = "T3")]
    public double? T3 { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(TgAb), TgAb },
        { nameof(TPO), TPO },
        { nameof(TSH), TSH },
        { nameof(T4), T4 },
        { nameof(T3), T3 },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumThyroids))]
    public virtual User User { get; set; } = null!;
}
