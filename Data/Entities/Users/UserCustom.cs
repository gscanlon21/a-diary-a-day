using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// A collection of sage advice.
/// </summary>
[Table("user_custom")]
[DebuggerDisplay("{Name} - {Type}")]
public class UserCustom : ICustom, IComparable<UserCustom>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? UserId { get; init; }

    /// <summary>
    /// A helpful snippet of fitness advice to show the users.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    public int Order { get; init; }

    [NotMapped]
    public int Count { get; init; }

    /// <summary>
    /// Either a link or a name that was the reference of the note.
    /// </summary>
    public string? Icon { get; init; }

    [NotMapped]
    public bool Selected { get; set; }

    /// <summary>
    /// Affirmations vs Fitness Tips.
    /// </summary>
    [Required]
    public CustomType Type { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserCustoms))]
    public User? User { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserActivity.UserCustoms))]
    public IList<UserActivity>? UserActivities { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserEmotion.UserCustoms))]
    public IList<UserEmotion>? UserEmotions { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSymptom.UserCustoms))]
    public IList<UserSymptom>? UserSymptoms { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserMedicine.UserCustoms))]
    public IList<UserMedicine>? UserMedicines { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserPeople.UserCustoms))]
    public IList<UserPeople>? UserPeoples { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Users.UserSleep.UserCustoms))]
    public IList<UserSleep>? UserSleeps { get; init; }

    public int CompareTo(UserCustom? other) => Order.CompareTo(other?.Order);
    public override bool Equals(object? obj) => obj is UserCustom custom && Id == custom.Id;
    public override int GetHashCode() => HashCode.Combine(Id);
}
