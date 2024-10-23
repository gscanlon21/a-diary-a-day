using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/f284f967-ed9e-4754-99fc-b32765b1c4a0/APA-DSM5TR-Level2AnxietyAdult.pdf
/// </summary>
[Table("user_anxiety"), Comment("User variation weight log")]
public class UserAnxiety
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(1, 5)]
    [Display(Name = "I felt fearful. ")]
    public int? Fearful { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt anxious.")]
    public int? Anxious { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt worried.")]
    public int? Worried { get; set; }

    [Range(1, 5)]
    [Display(Name = "I found it hard to focus on anything other than my anxiety. ")]
    public int? Focus { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt nervous.")]
    public int? Nervous { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt uneasy")]
    public int? Uneasy { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt tense")]
    public int? Tense { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserAnxieties))]
    public virtual User User { get; init; } = null!;
}
