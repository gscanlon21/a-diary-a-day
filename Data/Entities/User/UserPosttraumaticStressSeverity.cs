using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/1af5dc37-6370-4e72-94d8-e0224d8495f8/APA-DSM5TR-SeverityOfPosttraumaticStressSymptomsAdult.pdf
/// </summary>
[Table("user_posttraumatic_stress_severity"), Comment("User variation weight log")]
public class UserPosttraumaticStressSeverity
{
    public UserPosttraumaticStressSeverity() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [Range(0, 4)]
    [Display(Name = "Having “flashbacks,” that is, you suddenly acted or felt as if a stressful experience from the past was happening all over again (for example, you reexperienced parts of a stressful experience by seeing, hearing, smelling, or physically feeling parts of the experience)?")]
    public int? Flashbacks { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling very emotionally upset when something reminded you of a stressful experience")]
    public int? Upset { get; set; }

    [Range(0, 4)]
    [Display(Name = "Trying to avoid thoughts, feelings, or physical sensations that reminded you of a stressful experience")]
    public int? Avoid { get; set; }

    [Range(0, 4)]
    [Display(Name = "Thinking that a stressful event happened because you or someone else (who didn’t directly harm you) did something wrong or didn’t do everything possible to prevent it, or because of something about you?")]
    public int? StressfulEvent { get; set; }

    [Range(0, 4)]
    [Display(Name = "Having a very negative emotional state (for example, you were experiencing lots of fear, anger, guilt, shame, or horror) after a stressful experience?")]
    public int? NegativeEmotions { get; set; }

    [Range(0, 4)]
    [Display(Name = "Losing interest in activities you used to enjoy before having a stressful experience?")]
    public int? NoInterest { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being “super alert,” on guard, or constantly on the lookout for danger?")]
    public int? Alert { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling jumpy or easily startled when you hear an unexpected noise")]
    public int? Startled { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being extremely irritable or angry to the point where you yelled at other people, got into fights, or destroyed things?")]
    public int? Irritable { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Flashbacks, Upset, StressfulEvent, Avoid, Alert, Startled, Irritable, NegativeEmotions, NoInterest
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

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserPosttraumaticStressSeverities))]
    public virtual User User { get; set; } = null!;
}
