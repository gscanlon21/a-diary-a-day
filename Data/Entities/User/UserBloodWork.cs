using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_blood_work"), Comment("User variation weight log")]
public class UserBloodWork
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// The token should stop working after this date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(20, 200)]
    [Display(Name = "VitaminA")]
    public int? VitaminA { get; set; }

    [Range(1, 100)]
    [Display(Name = "Homocysteine")]
    public int? Homocysteine { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(VitaminA), VitaminA },
        { nameof(Homocysteine), Homocysteine },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserBloodWorks))]
    public virtual User User { get; set; } = null!;
}
