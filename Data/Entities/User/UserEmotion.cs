using Data.Entities.Footnote;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_emotion"), Comment("User variation weight log")]
public class UserEmotion
{
    public UserEmotion() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [JsonIgnore, InverseProperty(nameof(Entities.Footnote.UserCustom.UserEmotions))]
    public virtual List<UserCustom> UserCustoms { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserEmotions))]
    public virtual User User { get; init; } = null!;
}
