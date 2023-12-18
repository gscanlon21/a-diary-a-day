using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_sleep"), Comment("User variation weight log")]
public class UserSleep : IScore
{
    public UserSleep() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [Required]
    public Mood? Mood { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSleeps))]
    public virtual User User { get; init; } = null!;

    public List<int?> Items => new()
    {
        (int?)Mood
    };

    public int? ProratedScore => (int?)Mood;

    public int? AverageScore => null;
}
