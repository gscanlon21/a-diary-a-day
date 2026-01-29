using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_electolytes")]
public class UserSerumElectrolytes
{
    public class Consts
    {
        public const double CalciumMin = 0;
        public const double CalciumMax = 1000;
        public const double CalciumStep = .1;

        public const double CarbonDioxideMin = 0;
        public const double CarbonDioxideMax = 1000;
        public const double CarbonDioxideStep = .1;

        public const double ChlorideMin = 0;
        public const double ChlorideMax = 1000;
        public const double ChlorideStep = .1;

        public const double MagnesiumMin = 0;
        public const double MagnesiumMax = 1000;
        public const double MagnesiumStep = .1;

        public const double PotassiumMin = 0;
        public const double PotassiumMax = 1000;
        public const double PotassiumStep = .1;

        public const double SodiumMin = 0;
        public const double SodiumMax = 1000;
        public const double SodiumStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.CalciumMin, Consts.CalciumMax)]
    [Display(Name = "Calcium")]
    public double? Calcium { get; set; }

    [Range(Consts.CarbonDioxideMin, Consts.CarbonDioxideMax)]
    [Display(Name = "Carbon Dioxide")]
    public double? CarbonDioxide { get; set; }

    [Range(Consts.ChlorideMin, Consts.ChlorideMax)]
    [Display(Name = "Chloride")]
    public double? Chloride { get; set; }

    [Range(Consts.MagnesiumMin, Consts.MagnesiumMax)]
    [Display(Name = "Magnesium")]
    public double? Magnesium { get; set; }

    [Range(Consts.PotassiumMin, Consts.PotassiumMax)]
    [Display(Name = "Potassium")]
    public double? Potassium { get; set; }

    [Range(Consts.SodiumMin, Consts.SodiumMax)]
    [Display(Name = "Sodium")]
    public double? Sodium { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Calcium), Calcium },
        { nameof(CarbonDioxide), CarbonDioxide },
        { nameof(Chloride), Chloride },
        { nameof(Magnesium), Magnesium },
        { nameof(Potassium), Potassium },
        { nameof(Sodium), Sodium },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumElectrolytes))]
    public virtual User User { get; set; } = null!;
}
