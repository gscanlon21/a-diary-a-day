using Core.Models.AFeastADay;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// User's allergens.
/// </summary>
[Table("user_allergens")]
public class UserAllergens
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today.StartOfWeek();

    public IDictionary<Allergens, double> Allergens { get; set; } = new Dictionary<Allergens, double>();

    /// <summary>
    /// Get allergens that are not part of other allergens.
    /// </summary>
    public IEnumerable<KeyValuePair<Allergens, double>> SimpleAllergens => Allergens.Where(kv => kv.Key.PopCount() == 1);

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserAllergens))]
    public virtual User User { get; init; } = null!;
}
