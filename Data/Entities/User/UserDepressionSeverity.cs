using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/a3986be5-94af-42e7-afce-19234c2f4998/APA-DSM5TR-SeverityMeasureForDepressionAdult.pdf
/// </summary>
[Table("user_depression_severity"), Comment("User variation weight log")]
public class UserDepressionSeverity : IScore
{
    public UserDepressionSeverity() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [Range(0, 3)]
    [Display(Name = "Little interest or pleasure in doing things.")]
    public int? NoInterest { get; set; }

    [Range(0, 3)]
    [Display(Name = "Feeling down, depressed, or hopeless.")]
    public int? Hopeless { get; set; }

    [Range(0, 3)]
    [Display(Name = "Trouble falling or staying asleep, or sleeping too much.")]
    public int? Sleeping { get; set; }

    [Range(0, 3)]
    [Display(Name = "Feeling tired or having little energy.")]
    public int? NoEnergy { get; set; }

    [Range(0, 3)]
    [Display(Name = "Poor appetite or overeating.")]
    public int? Eating { get; set; }

    [Range(0, 3)]
    [Display(Name = "Feeling bad about yourself—or that you are a failure or have let yourself or your family down.")]
    public int? FeelingBad { get; set; }

    [Range(0, 3)]
    [Display(Name = "Trouble concentrating on things, such as reading the newspaper or watching television.")]
    public int? NoConcentration { get; set; }

    [Range(0, 3)]
    [Display(Name = "Moving or speaking so slowly that other people could have noticed? Or the opposite—being so fidgety or restless that you have been moving around a lot more than usual.")]
    public int? Slowly { get; set; }

    [Range(0, 3)]
    [Display(Name = "Thoughts that you would be better off dead or of hurting yourself in some way.")]
    public int? BetterOffDead { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        NoInterest, Hopeless, Sleeping, NoEnergy, Eating, FeelingBad, NoConcentration, Slowly, BetterOffDead
    };

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? ProratedScore => Items.Count * Items.Sum() / Items.Count(d => d.HasValue);

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? AverageScore => Items.Count(d => d.HasValue) == Items.Count ? Items.Sum() / Items.Count : null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserDepressionSeverities))]
    public virtual User User { get; set; } = null!;
}
