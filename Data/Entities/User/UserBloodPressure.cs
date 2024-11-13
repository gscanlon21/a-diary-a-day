using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Blood pressure measurement tracking.
/// https://www.health.harvard.edu/topics/blood-pressure
/// </summary>
[Table("user_blood_pressure")]
public class UserBloodPressure : IScore
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    /// <summary>
    /// The top number. It represents the pressure the heart generates when it beats to pump blood to the rest of the body.
    /// </summary>
    [Required]
    public int SystolicPressure { get; set; }

    /// <summary>
    /// The bottom number. It refers to the pressure in the blood vessels between heartbeats.
    /// </summary>
    [Required]
    public int DiastolicPressure { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserBloodPressures))]
    public virtual User User { get; set; } = null!;

    public List<int?> Items => [SystolicPressure, DiastolicPressure];

    public int? ProratedScore => Items.Sum();

    public double? AverageScore => Items.Sum() / (double)Items.Count;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserBloodPressure other
        && other.Id == Id;
}
