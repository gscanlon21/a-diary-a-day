using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Blood pressure measurement tracking.
/// https://www.health.harvard.edu/topics/blood-pressure
/// </summary>
[Table("user_body_temp")]
public class UserBodyTemp
{
    public class Consts
    {
        public const double BodyTempMin = 90;
        public const double BodyTempDefault = 98.6;
        public const double BodyTempMax = 110;
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
    [Required, Range(Consts.BodyTempMin, Consts.BodyTempMax)]
    [Display(Name = "Body Temp")]
    public double BodyTemp { get; set; } = Consts.BodyTempDefault;

  
    [NotMapped]
    public Dictionary<string, double> Items => new()
    {
        { nameof(BodyTemp), BodyTemp },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserBodyTemps))]
    public virtual User User { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserBloodPressure other
        && other.Id == Id;
}
