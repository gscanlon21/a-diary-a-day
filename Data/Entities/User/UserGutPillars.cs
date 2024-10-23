using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_pillars"), Comment("User variation weight log")]
public class UserGutPillars
{
    public class Consts
    {
        public const int PlatletCountMin = 100;
        public const int PlatletCountMax = 500;
        public const int PlatletCountStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(40, 240)]
    [Display(Name = "Digestion")]
    public int? Digestion { get; set; }

    [Range(40, 240)]
    [Display(Name = "Inflammation")]
    public int? Inflammation { get; set; }

    [Range(40, 240)]
    [Display(Name = "Gut Dysbiosis")]
    public int? GutDysbiosis { get; set; }

    [Range(40, 240)]
    [Display(Name = "Intestinal Permeability")]
    public int? IntestinalPermeability { get; set; }

    [Range(40, 240)]
    [Display(Name = "Nervous System")]
    public int? NervousSystem { get; set; }

    [Range(40, 240)]
    [Display(Name = "Diversity Score")]
    public int? DiversityScore { get; set; }

    [Range(40, 240)]
    [Display(Name = "Immune Readiness Score")]
    public int? ImmuneReadinessScore { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(ImmuneReadinessScore), ImmuneReadinessScore },
        { nameof(DiversityScore), DiversityScore },
        { nameof(NervousSystem), NervousSystem },
        { nameof(IntestinalPermeability), IntestinalPermeability },
        { nameof(GutDysbiosis), GutDysbiosis },
        { nameof(Inflammation), Inflammation },
        { nameof(Digestion), Digestion },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutPillars))]
    public virtual User User { get; set; } = null!;
}
