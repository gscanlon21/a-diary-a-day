using Core.Models.User;
using Data.Entities.Footnote;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_sleep"), Comment("User variation weight log")]
public class UserSleep : IScore
{
    public UserSleep() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [Required, Display(Name = "Sleep Duration")]
    public SleepDuration SleepDuration { get; set; } = SleepDuration.JustRight;

    [Required, Display(Name = "Sleep Time")]
    public SleepTime SleepTime { get; set; } = SleepTime.InBedOnTime;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSleeps))]
    public virtual User User { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserCustom.UserSleeps))]
    public virtual List<UserCustom> UserCustoms { get; init; } = [];

    public List<int?> Items => new()
    {
        (int?)SleepDuration, (int?)SleepTime
    };

    public int? ProratedScore => Items.Sum();

    public double? AverageScore => Items.Sum() / (double)Items.Count;
}
