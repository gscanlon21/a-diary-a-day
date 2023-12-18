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

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? Score { get; set; }

    [Range(0, 4)]
    [Display(Name = "Having “flashbacks,” that is, you suddenly acted or \r\nfelt as if a stressful experience from the past was \r\nhappening all over again (for example, you \r\nreexperienced parts of a stressful experience by \r\nseeing, hearing, smelling, or physically feeling parts \r\nof the experience)?")]
    public int? Flashbacks { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling very emotionally upset when something \r\nreminded you of a stressful experience")]
    public int? Upset { get; set; }

    [Range(0, 4)]
    [Display(Name = "Trying to avoid thoughts, feelings, or physical \r\nsensations that reminded you of a stressful \r\nexperience")]
    public int? Avoid { get; set; }

    [Range(0, 4)]
    [Display(Name = "Thinking that a stressful event happened because you \r\nor someone else (who didn’t directly harm you) did \r\nsomething wrong or didn’t do everything possible to \r\nprevent it, or because of something about you?\r\n")]
    public int? StressfulEvent { get; set; }

    [Range(0, 4)]
    [Display(Name = "Having a very negative emotional state (for example, \r\nyou were experiencing lots of fear, anger, guilt, \r\nshame, or horror) after a stressful experience?")]
    public int? NegativeEmotions { get; set; }

    [Range(0, 4)]
    [Display(Name = "Losing interest in activities you used to enjoy before \r\nhaving a stressful experience?")]
    public int? NoInterest { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being “super alert,” on guard, or constantly on the \r\nlookout for danger?")]
    public int? Alert { get; set; }

    [Range(0, 4)]
    [Display(Name = "Feeling jumpy or easily startled when you hear an \r\nunexpected noise")]
    public int? Startled { get; set; }

    [Range(0, 4)]
    [Display(Name = "Being extremely irritable or angry to the point where \r\nyou yelled at other people, got into fights, or \r\ndestroyed things?\r\n")]
    public int? Irritable { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Flashbacks, Upset, StressfulEvent, Avoid, Alert, Startled, Irritable, NegativeEmotions, NoInterest
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserPosttraumaticStressSeverities))]
    public virtual User User { get; set; } = null!;
}
