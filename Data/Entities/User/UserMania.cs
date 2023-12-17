using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


public enum ManiaQ1
{
    [Display(Name = " do not feel happier or more cheerful than usual.")]
    One = 1,

    [Display(Name = "I occasionally feel happier or more cheerful than usua")]
    Two = 2,

    [Display(Name = "I often feel happier or more cheerful than usual")]
    Three = 3,

    [Display(Name = "I feel happier or more cheerful than usual most of the time.")]
    Four = 4,

    [Display(Name = "I feel happier of more cheerful than usual all of the time")]
    Five = 5,
}

public enum ManiaQ2
{
    [Display(Name = "I do not feel more self-confident than usual")]
    One = 1,

    [Display(Name = "I occasionally feel more self-confident than usual.")]
    Two = 2,

    [Display(Name = "I often feel more self-confident than usual")]
    Three = 3,

    [Display(Name = "I frequently feel more self-confident than usual")]
    Four = 4,

    [Display(Name = "I feel extremely self-confident all of the time.")]
    Five = 5,
}

public enum ManiaQ3
{
    [Display(Name = "I do not need less sleep than usual.")]
    One = 1,

    [Display(Name = "I occasionally need less sleep than usual")]
    Two = 2,

    [Display(Name = "I often need less sleep than usual.")]
    Three = 3,

    [Display(Name = "I frequently need less sleep than usual.")]
    Four = 4,

    [Display(Name = "I can go all day and all night without any sleep and still not feel tired")]
    Five = 5,
}

public enum ManiaQ4
{
    [Display(Name = "I do not talk more than usual.")]
    One = 1,

    [Display(Name = "I occasionally talk more than usual.")]
    Two = 2,

    [Display(Name = "I often talk more than usual.")]
    Three = 3,

    [Display(Name = "I frequently talk more than usual.")]
    Four = 4,

    [Display(Name = "I talk constantly and cannot be interrupted")]
    Five = 5,
}

public enum ManiaQ5
{
    [Display(Name = "I have not been more active (either socially, sexually, at work, home, or school) than usual.")]
    One = 1,

    [Display(Name = "I have occasionally been more active than usual.")]
    Two = 2,

    [Display(Name = "I have often been more active than usual.")]
    Three = 3,

    [Display(Name = "I have frequently been more active than usual.")]
    Four = 4,

    [Display(Name = " am constantly more active or on the go all the time")]
    Five = 5,
}

/// <summary>
/// https://www.psychiatry.org/getmedia/c1783d55-268a-47b2-9932-a549b21c8d64/APA-DSM5TR-Level2ManiaAdult.pdf
/// </summary>
[Table("user_mania"), Comment("User variation weight log")]
public class UserMania
{
    public UserMania() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? Score { get; set; }

    [Range(1, 5)]
    [Display(Name = "Question1")]
    public ManiaQ1? Question1 { get; set; }

    [Range(1, 5)]
    [Display(Name = "Question2")]
    public ManiaQ2? Question2 { get; set; }

    [Range(1, 5)]
    [Display(Name = "Question3")]
    public ManiaQ3? Question3 { get; set; }

    [Range(1, 5)]
    [Display(Name = "Question4")]
    public ManiaQ4? Question4 { get; set; }

    [Range(1, 5)]
    [Display(Name = "Question5")]
    public ManiaQ5? Question5 { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserManias))]
    public virtual User User { get; init; } = null!;
}
