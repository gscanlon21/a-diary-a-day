using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_metabolic")]
public class UserSerumMetabolic
{
    public class Consts
    {
        public const double GlucoseMin = 1;
        public const double GlucoseMax = 1000;
        public const double GlucoseStep = .1;

        public const double UricAcidMin = 1;
        public const double UricAcidMax = 1000;
        public const double UricAcidStep = .1;

        public const double HbA1cMin = 1;
        public const double HbA1cMax = 1000;
        public const double HbA1cStep = .1;

        public const double InsulinMin = 1;
        public const double InsulinMax = 1000;
        public const double InsulinStep = .1;

        public const double LeptinMin = 1;
        public const double LeptinMax = 1000;
        public const double LeptinStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.GlucoseMin, Consts.GlucoseMax)]
    [Display(Name = "Glucose")]
    public double? Glucose { get; set; }

    [Range(Consts.UricAcidMin, Consts.UricAcidMax)]
    [Display(Name = "Uric Acid")]
    public double? UricAcid { get; set; }

    [Range(Consts.HbA1cMin, Consts.HbA1cMax)]
    [Display(Name = "HbA1c")]
    public double? HbA1c { get; set; }

    [Range(Consts.InsulinMin, Consts.InsulinMax)]
    [Display(Name = "Insulin")]
    public double? Insulin { get; set; }

    [Range(Consts.LeptinMin, Consts.LeptinMax)]
    [Display(Name = "Leptin")]
    public double? Leptin { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Glucose), Glucose },
        { nameof(UricAcid), UricAcid },
        { nameof(HbA1c), HbA1c },
        { nameof(Insulin), Insulin },
        { nameof(Leptin), Leptin },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumMetabolics))]
    public virtual User User { get; set; } = null!;
}
