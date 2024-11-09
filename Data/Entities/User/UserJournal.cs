using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_journal")]
public class UserJournal
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserJournal() { }

    public UserJournal(User user, string text)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
        Value = text;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public string? Value { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserJournals))]
    public virtual User User { get; set; } = null!;
}
