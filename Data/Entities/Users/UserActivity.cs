using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_activity")]
public class UserActivity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [JsonInclude, InverseProperty(nameof(UserCustom.UserActivities))]
    public virtual IList<UserCustom> UserCustoms { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserActivities))]
    public virtual User User { get; init; } = null!;
}
