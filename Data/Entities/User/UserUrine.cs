using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_urine")]
public class UserUrine
{
    public class Consts
    {
        public const double AlbuminMin = 0;
        public const double AlbuminMax = 10;
        public const double AlbuminStep = .1;

        public const double BilirubinMin = 0;
        public const double BilirubinMax = 10;
        public const double BilirubinStep = .1;

        public const double GlucoseMin = 0;
        public const double GlucoseMax = 10;
        public const double GlucoseStep = .1;

        public const double KetonesMin = 0;
        public const double KetonesMax = 10;
        public const double KetonesStep = .1;

        public const double LeukocyteMin = 0;
        public const double LeukocyteMax = 10;
        public const double LeukocyteStep = .1;

        public const double HomocysteineMin = 0;
        public const double HomocysteineMax = 10;
        public const double HomocysteineStep = .1;

        public const double NitrateMin = 0;
        public const double NitrateMax = 10;
        public const double NitrateStep = .1;

        public const double OccultBloodMin = 0;
        public const double OccultBloodMax = 10;
        public const double OccultBloodStep = .1;

        public const double ProteinMin = 0;
        public const double ProteinMax = 10;
        public const double ProteinStep = .1;

        public const double SpecificGravityMin = 0;
        public const double SpecificGravityMax = 10;
        public const double SpecificGravityStep = .001;

        public const double PHMin = 0;
        public const double PHMax = 10;
        public const double PHStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.AlbuminMin, Consts.AlbuminMax)]
    [Display(Name = "Albumin")]
    public double? Albumin { get; set; }

    [Range(Consts.BilirubinMin, Consts.BilirubinMax)]
    [Display(Name = "Bilirubin")]
    public double? Bilirubin { get; set; }

    [Range(Consts.GlucoseMin, Consts.GlucoseMax)]
    [Display(Name = "Glucose")]
    public double? Glucose { get; set; }

    [Range(Consts.KetonesMin, Consts.KetonesMax)]
    [Display(Name = "Ketones")]
    public double? Ketones { get; set; }

    [Range(Consts.LeukocyteMin, Consts.LeukocyteMax)]
    [Display(Name = "Leukocyte")]
    public double? Leukocyte { get; set; }

    [Range(Consts.NitrateMin, Consts.NitrateMax)]
    [Display(Name = "Nitrate")]
    public double? Nitrate { get; set; }

    [Range(Consts.OccultBloodMin, Consts.OccultBloodMax)]
    [Display(Name = "Occult Blood")]
    public double? OccultBlood { get; set; }

    [Range(Consts.ProteinMin, Consts.ProteinMax)]
    [Display(Name = "Protein")]
    public double? Protein { get; set; }

    [Range(Consts.SpecificGravityMin, Consts.SpecificGravityMax)]
    [Display(Name = "Specific Gravity")]
    public double? SpecificGravity { get; set; }

    [Range(Consts.PHMin, Consts.PHMax)]
    [Display(Name = "pH")]
    public double? PH { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Albumin), Albumin },
        { nameof(Bilirubin), Bilirubin },
        { nameof(Glucose), Glucose },
        { nameof(Ketones), Ketones },
        { nameof(Leukocyte), Leukocyte },
        { nameof(Nitrate), Nitrate },
        { nameof(OccultBlood), OccultBlood },
        { nameof(Protein), Protein },
        { nameof(SpecificGravity), SpecificGravity },
        { nameof(PH), PH },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserUrines))]
    public virtual User User { get; set; } = null!;
}
