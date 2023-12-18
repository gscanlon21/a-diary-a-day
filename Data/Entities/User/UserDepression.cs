using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://www.psychiatry.org/getmedia/4326c940-f414-4f2c-acec-bd8299a3cf14/APA-DSM5TR-Level2DepressionAdult.pdf
/// </summary>
[Table("user_depression"), Comment("User variation weight log")]
public class UserDepression
{
    public UserDepression() { }

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
    [Display(Name = "I felt worthless.")]
    public int? Worthless { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt that I had nothing to look forward to.")]
    public int? NoFuture { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt helpless.")]
    public int? Helpless { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt sad.")]
    public int? Sad { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt like a failure.")]
    public int? Failure { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt depressed.")]
    public int? Depressed { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt unhappy.")]
    public int? Unhappy { get; set; }

    [Range(1, 5)]
    [Display(Name = "I felt hopeless.")]
    public int? Hopeless { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Worthless, NoFuture, Helpless, Sad, Failure, Depressed, Unhappy, Hopeless
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserDepressions))]
    public virtual User User { get; set; } = null!;
}
