using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Tracks component image upload dates.
/// </summary>
[Table("user_component")]
public class UserComponent
{
    /// <summary>
    /// Creates a new token for the user.
    /// </summary>
    public UserComponent(int userId, Component component)
    {
        UserId = userId;
        Component = component;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string? Name { get; init; }

    /// <summary>
    /// Used as a unique user identifier in email links. This valus is switched out every day to expire old links.
    /// 
    /// This is kinda like a bearer token.
    /// </summary>
    [Required]
    public Component Component { get; init; }

    [Required]
    public int UserId { get; init; }

    [Required]
    public DateOnly LastUpload { get; set; } = DateHelpers.Today;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserComponents))]
    public virtual User User { get; init; } = null!;
}
