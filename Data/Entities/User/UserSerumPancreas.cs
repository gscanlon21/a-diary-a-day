using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_pancreas")]
public class UserSerumPancreas
{
    public class Consts
    {
        public const int AmylaseMin = 0;
        public const int AmylaseMax = 250;
        public const int AmylaseStep = 1;

        public const int LipaseMin = 0;
        public const int LipaseMax = 100;
        public const int LipaseStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.AmylaseMin, Consts.AmylaseMax)]
    [Display(Name = "Amylase")]
    public int? Amylase { get; set; }

    [Range(Consts.LipaseMin, Consts.LipaseMax)]
    [Display(Name = "Lipase")]
    public int? Lipase { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Amylase), Amylase },
        { nameof(Lipase), Lipase },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumPancreas))]
    public virtual User User { get; set; } = null!;
}
