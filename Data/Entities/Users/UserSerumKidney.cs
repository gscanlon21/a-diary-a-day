using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_kidney")]
public class UserSerumKidney
{
    public class Consts
    {
        public const double AlbuminUrineMin = 0;
        public const double AlbuminUrineMax = 1000;
        public const double AlbuminUrineStep = .1;

        public const double BUNMin = 0;
        public const double BUNMax = 1000;
        public const double BUNStep = .1;

        public const double CalciumMin = 0;
        public const double CalciumMax = 1000;
        public const double CalciumStep = .1;

        public const double ChlorideMin = 0;
        public const double ChlorideMax = 1000;
        public const double ChlorideStep = .1;

        public const double HomocysteineMin = 0;
        public const double HomocysteineMax = 1000;
        public const double HomocysteineStep = .1;

        public const double CreatinineMin = 0;
        public const double CreatinineMax = 1000;
        public const double CreatinineStep = .1;

        public const double EGFRMin = 0;
        public const double EGFRMax = 1000;
        public const double EGFRStep = .1;

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

    [Range(Consts.AlbuminUrineMin, Consts.AlbuminUrineMax)]
    [Display(Name = "Albumin Urine")]
    public double? AlbuminUrine { get; set; }

    [Range(Consts.BUNMin, Consts.BUNMax)]
    [Display(Name = "BUN")]
    public double? BUN { get; set; }

    [Range(Consts.CalciumMin, Consts.CalciumMax)]
    [Display(Name = "Calcium")]
    public double? Calcium { get; set; }

    [Range(Consts.ChlorideMin, Consts.ChlorideMax)]
    [Display(Name = "Chloride")]
    public double? Chloride { get; set; }

    [Range(Consts.CreatinineMin, Consts.CreatinineMax)]
    [Display(Name = "Creatinine")]
    public double? Creatinine { get; set; }

    [Range(Consts.EGFRMin, Consts.EGFRMax)]
    [Display(Name = "eGFR")]
    public double? EGFR { get; set; }

    [Range(Consts.PotassiumMin, Consts.PotassiumMax)]
    [Display(Name = "Potassium")]
    public double? Potassium { get; set; }

    [Range(Consts.SodiumMin, Consts.SodiumMax)]
    [Display(Name = "Sodium")]
    public double? Sodium { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(AlbuminUrine), AlbuminUrine },
        { nameof(BUN), BUN },
        { nameof(Calcium), Calcium },
        { nameof(Chloride), Chloride },
        { nameof(Creatinine), Creatinine },
        { nameof(EGFR), EGFR },
        { nameof(Potassium), Potassium },
        { nameof(Sodium), Sodium },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumKidneys))]
    public virtual User User { get; set; } = null!;
}
