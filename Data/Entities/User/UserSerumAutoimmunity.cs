using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_autoimmunity")]
public class UserSerumAutoimmunity
{
    public class Consts
    {
        public const int AntinuclearAntibodiesMin = 0;
        public const int AntinuclearAntibodiesMax = 100;
        public const int AntinuclearAntibodiesStep = 1;

        public const int RheumatoidFactorMin = 0;
        public const int RheumatoidFactorMax = 100;
        public const int RheumatoidFactorStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.AntinuclearAntibodiesMin, Consts.AntinuclearAntibodiesMax)]
    [Display(Name = "Antinuclear Antibodies")]
    public int? AntinuclearAntibodies { get; set; }

    [Range(Consts.RheumatoidFactorMin, Consts.RheumatoidFactorMax)]
    [Display(Name = "Rheumatoid Factor")]
    public int? RheumatoidFactor { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(AntinuclearAntibodies), AntinuclearAntibodies },
        { nameof(RheumatoidFactor), RheumatoidFactor },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumAutoimmunitys))]
    public virtual User User { get; set; } = null!;
}
