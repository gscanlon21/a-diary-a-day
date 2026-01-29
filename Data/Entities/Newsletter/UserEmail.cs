using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's journal entry email.
/// </summary>
[Table("user_email")]
public class UserEmail
{
    [Obsolete("Public parameterless constructor required for EF Core.", error: true)]
    public UserEmail() { }

    public UserEmail(Users.User user)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
    }

    /// <summary>
    /// UTC date the email was created.
    /// </summary>
    [Required]
    public DateOnly Date { get; set; } = DateHelpers.Today;

    /// <summary>
    /// UTC datetime the email should send after.
    /// </summary>
    [Required]
    public DateTime SendAfter { get; set; } = DateTime.UtcNow;

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// Third-party ID for email checking delivery of emails.
    /// </summary>
    public string? SenderId { get; set; }

    [Required]
    public string Subject { get; set; } = null!;

    [Required]
    public string Body { get; set; } = null!;

    public EmailStatus EmailStatus { get; set; }

    public int SendAttempts { get; set; }

    /// <summary>
    /// The last error encountered.
    /// </summary>
    public string? LastError { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserEmails))]
    public virtual Users.User User { get; private init; } = null!;
}
