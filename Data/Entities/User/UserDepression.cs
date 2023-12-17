using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_depression"), Comment("User variation weight log")]
public class UserDepression
{
    public UserDepression() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Range(1, 5)]
    public int? Worthless { get; set; }

    [Range(1, 5)]
    public int? NoFuture { get; set; }

    [Range(1, 5)]
    public int? Helpless { get; set; }

    [Range(1, 5)]
    public int? Sad { get; set; }

    [Range(1, 5)]
    public int? Failure { get; set; }

    [Range(1, 5)]
    public int? Depressed { get; set; }

    [Range(1, 5)]
    public int? Unhappy { get; set; }

    [Range(1, 5)]
    public int? Hopeless { get; set; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserDepressions))]
    public virtual User User { get; init; } = null!;
}
