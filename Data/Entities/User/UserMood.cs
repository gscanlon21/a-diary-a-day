using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_mood"), Comment("User variation weight log")]
public class UserMood : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Required]
    public Mood Mood { get; set; } = Mood.Decent;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserMoods))]
    public virtual User User { get; init; } = null!;

    public List<int?> Items => new()
    {
        (int?)Mood
    };

    public int? ProratedScore => Items.Sum();

    public double? AverageScore => Items.Sum() / (double)Items.Count;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserMood other
        && other.Id == Id;
}
