using Core.Models.Exercise;
using Data.Entities.User;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_mood"), Comment("A day's workout routine")]
public class UserMood
{
    [Obsolete("Public parameterless constructor required for EF Core .AsSplitQuery()", error: true)]
    public UserMood() { }

    internal UserMood(DateOnly date, WorkoutContext context) : this(date, context.User) { }

    public UserMood(DateOnly date, User.User user)
    {
        Date = date;
        User = user;
        Intensity = user.Intensity;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; private init; }

    /// <summary>
    /// The date the workout is for, using the user's UTC offset date.
    /// </summary>
    [Required]
    public DateOnly Date { get; private init; }

    /// <summary>
    /// How much weight the user is able to lift.
    /// </summary>
    [Required, Range(0, 5)]
    public int Weight { get; set; } = 0;

    /// <summary>
    /// What was the workout split used when this newsletter was sent?
    /// </summary>
    [Required]
    public Intensity Intensity { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserMoods))]
    public virtual User.User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserMoodValue.UserMood))]
    public virtual ICollection<UserMoodValue> UserVariationWeights { get; private init; } = new List<UserMoodValue>();
}
