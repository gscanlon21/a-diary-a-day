using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_journal"), Comment("User variation weight log")]
public class UserJournal
{
    public UserJournal() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public string? Value { get; set; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserJournals))]
    public virtual User User { get; set; } = null!;
}
