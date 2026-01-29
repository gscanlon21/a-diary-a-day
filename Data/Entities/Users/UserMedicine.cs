using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_medicine")]
public class UserMedicine
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [JsonIgnore, InverseProperty(nameof(UserCustom.UserMedicines))]
    public virtual List<UserCustom> UserCustoms { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserMedicines))]
    public virtual User User { get; init; } = null!;
}
