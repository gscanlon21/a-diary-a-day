using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/b1a256c4-1304-4610-8aca-0cc70b46ff53/APA-DSM5TR-SeverityMeasureForGeneralizedAnxietyDisorderAdult.pdf
/// </summary>
[Table("user_generalized_anxiety_severity"), Comment("User variation weight log")]
public class UserGeneralizedAnxietySeverity : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 4)]
    [Display(Name = "felt moments of sudden terror, fear, or fright.")]
    public int? Fright { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous.")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts of bad things happening, such as family tragedy, ill health, loss of a job, or accident.")]
    public int? Accidents { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble breathing, faint, or shaky.")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, or had trouble relaxing or trouble sleeping.")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter, situations about which I worry.")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "left situations early or participated only minimally due to worries.")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent lots of time making decisions, putting off making decisions, or preparing for situations, due to worries.")]
    public int? Time { get; set; }

    [Range(0, 4)]
    [Display(Name = "sought reassurance from others due to worries.")]
    public int? Reassurance { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with anxiety (e.g., alcohol or medication, superstitious objects, or other people).")]
    public int? Cope { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Fright, Nervous, Accidents, Heart, Tense, Avoided, LeftEarly, Time, Reassurance, Cope
    };

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? ProratedScore => Items.Any(d => d.HasValue) ? Convert.ToInt32(Items.Count * Items.Sum() / (double)Items.Count(d => d.HasValue)) : null;

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public double? AverageScore => Items.All(d => d.HasValue) ? Items.Sum() / (double)Items.Count : null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGeneralizedAnxietySeverities))]
    public virtual User User { get; set; } = null!;
}
