using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/a56cc2a0-3818-4975-bbcb-4a047e1ffbea/APA-DSM5TR-Level2AngerAdult.pdf
/// </summary>
[Table("user_anger"), Comment("User variation weight log")]
public class UserAnger
{
    public UserAnger() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [Range(1, 5)]
    [Display(Name = "I was irritated more than people knew")]
    public int? Irritated { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt angry.")]
    public int? Angry { get; set; }

    [Range(1, 5)]
    [Display(Name = "I  felt like I was ready to explode")]
    public int? Explode { get; set; }

    [Range(1, 5)]
    [Display(Name = "I was grouchy.")]
    public int? Grouchy { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt annoyed.")]
    public int? Annoyed { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserAngers))]
    public virtual User User { get; init; } = null!;
}
