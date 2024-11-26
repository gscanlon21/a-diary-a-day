using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_stress")]
public class UserSerumStress
{
    public class Consts
    {
        public const int DHEASulfateMin = 0;
        public const int DHEASulfateMax = 1000;
        public const int DHEASulfateStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.DHEASulfateMin, Consts.DHEASulfateMax)]
    [Display(Name = "DHEA Sulfate")]
    public int? DHEASulfate { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(DHEASulfate), DHEASulfate },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumStress))]
    public virtual User User { get; set; } = null!;
}
