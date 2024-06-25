using Core.Code.Helpers;
using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's progression level of an exercise.
/// 
/// TODO Scopes.
/// TODO Single-use tokens.
/// </summary>
[Table("user_component"), Comment("Auth tokens for a user")]
public class UserComponent
{
    public UserComponent() { }

    /// <summary>
    /// Creates a new token for the user.
    /// </summary>
    public UserComponent(int userId, Components component)
    {
        UserId = userId;
        Component = component;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// Used as a unique user identifier in email links. This valus is switched out every day to expire old links.
    /// 
    /// This is kinda like a bearer token.
    /// </summary>
    [Required]
    public Components Component { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly LastUpload { get; set; } = DateHelpers.Today;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserComponents))]
    public virtual User User { get; init; } = null!;
}
