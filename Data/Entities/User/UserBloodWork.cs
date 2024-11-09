using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_blood_work")]
public class UserBloodWork
{
    public class Consts
    {
        public const int VitaminAMin = 20;
        public const int VitaminAMax = 200;
        public const int VitaminAStep = 1;

        public const double HomocysteineMin = 1;
        public const double HomocysteineMax = 100;
        public const double HomocysteineStep = .5;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.VitaminAMin, Consts.VitaminAMax)]
    [Display(Name = "VitaminA")]
    public int? VitaminA { get; set; }

    [Range(Consts.HomocysteineMin, Consts.HomocysteineMax)]
    [Display(Name = "Homocysteine")]
    public double? Homocysteine { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(VitaminA), VitaminA },
        { nameof(Homocysteine), Homocysteine },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserBloodWorks))]
    public virtual User User { get; set; } = null!;
}
