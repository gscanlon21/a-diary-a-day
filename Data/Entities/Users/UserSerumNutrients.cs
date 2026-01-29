using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_nutrients")]
public class UserSerumNutrients
{
    public class Consts
    {
        public const double IronMin = 1;
        public const double IronMax = 1000;
        public const double IronStep = .1;

        public const double FerritinMin = 1;
        public const double FerritinMax = 1000;
        public const double FerritinStep = .1;

        public const double HomocysteineMin = 1;
        public const double HomocysteineMax = 1000;
        public const double HomocysteineStep = .1;

        public const double CalciumMin = 1;
        public const double CalciumMax = 1000;
        public const double CalciumStep = .1;

        public const double IronSatMin = 1;
        public const double IronSatMax = 1000;
        public const double IronSatStep = .1;

        public const double IronBindingCapacityMin = 1;
        public const double IronBindingCapacityMax = 1000;
        public const double IronBindingCapacityStep = .1;

        public const double MagnesiumMin = 1;
        public const double MagnesiumMax = 1000;
        public const double MagnesiumStep = .1;

        public const double MMAMin = 1;
        public const double MMAMax = 1000;
        public const double MMAStep = .1;

        public const double VitaminDMin = 1;
        public const double VitaminDMax = 1000;
        public const double VitaminDStep = .1;

        public const double ZincMin = 1;
        public const double ZincMax = 1000;
        public const double ZincStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.FerritinMin, Consts.FerritinMax)]
    [Display(Name = "Ferritin")]
    public double? Ferritin { get; set; }

    [Range(Consts.HomocysteineMin, Consts.HomocysteineMax)]
    [Display(Name = "Homocysteine")]
    public double? Homocysteine { get; set; }

    [Range(Consts.CalciumMin, Consts.CalciumMax)]
    [Display(Name = "Calcium")]
    public double? Calcium { get; set; }

    [Range(Consts.IronMin, Consts.IronMax)]
    [Display(Name = "Iron")]
    public double? Iron { get; set; }

    [Range(Consts.IronSatMin, Consts.IronSatMax)]
    [Display(Name = "Iron % Saturation")]
    public double? IronSat { get; set; }

    [Range(Consts.IronBindingCapacityMin, Consts.IronBindingCapacityMax)]
    [Display(Name = "Iron Bindin gCapacity")]
    public double? IronBindingCapacity { get; set; }

    [Range(Consts.MagnesiumMin, Consts.MagnesiumMax)]
    [Display(Name = "Magnesium")]
    public double? Magnesium { get; set; }

    [Range(Consts.MMAMin, Consts.MMAMax)]
    [Display(Name = "MMA")]
    public double? MMA { get; set; }

    [Range(Consts.VitaminDMin, Consts.VitaminDMax)]
    [Display(Name = "Vitamin D")]
    public double? VitaminD { get; set; }

    [Range(Consts.ZincMin, Consts.ZincMax)]
    [Display(Name = "Zinc")]
    public double? Zinc { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Ferritin), Ferritin },
        { nameof(Homocysteine), Homocysteine },
        { nameof(Calcium), Calcium },
        { nameof(Iron), Iron },
        { nameof(IronSat), IronSat },
        { nameof(IronBindingCapacity), IronBindingCapacity },
        { nameof(Magnesium), Magnesium },
        { nameof(MMA), MMA },
        { nameof(Zinc), Zinc },
        { nameof(VitaminD), VitaminD },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumNutrients))]
    public virtual User User { get; set; } = null!;
}
