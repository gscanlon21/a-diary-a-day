using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_feast_allergens"), Comment("User variation weight log")]
public class UserFeastAllergens
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today.StartOfWeek();

    public IDictionary<Allergy, double> Allergens { get; set; } = new Dictionary<Allergy, double>();

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFeastAllergens))]
    public virtual User User { get; init; } = null!;
}
