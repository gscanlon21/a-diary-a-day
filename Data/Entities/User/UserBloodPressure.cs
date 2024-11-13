using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Blood pressure measurement tracking.
/// https://www.health.harvard.edu/topics/blood-pressure
/// </summary>
[Table("user_blood_pressure")]
public class UserBloodPressure
{
    public class Consts
    {
        public const int SystolicPressureMin = 80;
        public const int SystolicPressureMax = 160;

        public const int DiastolicPressureMin = 50;
        public const int DiastolicPressureMax = 100;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    /// <summary>
    /// The top number. It represents the pressure the heart generates when it beats to pump blood to the rest of the body.
    /// </summary>
    [Required, Range(Consts.SystolicPressureMin, Consts.SystolicPressureMax)]
    [Display(Name = "Systolic Pressure")]
    public int SystolicPressure { get; set; }

    /// <summary>
    /// The bottom number. It refers to the pressure in the blood vessels between heartbeats.
    /// </summary>
    [Required, Range(Consts.DiastolicPressureMin, Consts.DiastolicPressureMax)]
    [Display(Name = "Diastolic Pressure")]
    public int DiastolicPressure { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserBloodPressures))]
    public virtual User User { get; set; } = null!;

    [NotMapped]
    public Dictionary<string, int> Items => new()
    {
        { nameof(SystolicPressure), SystolicPressure },
        { nameof(DiastolicPressure), DiastolicPressure },
    };

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserBloodPressure other
        && other.Id == Id;
}
