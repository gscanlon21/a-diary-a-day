using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/40a74f7f-d18c-4088-8464-653073c74452/APA-DSM5TR-SeverityOfDissociativeSymptomsAdult.pdf
/// </summary>
[Table("user_dissociative_severity"), Comment("User variation weight log")]
public class UserDissociativeSeverity
{
    public UserDissociativeSeverity() { }

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

    [Range(0, 4)]
    [Display(Name = "I find myself staring into space and thinking of nothing.")]
    public int? Nothing { get; set; }

    [Range(0, 4)]
    [Display(Name = "People, objects, or the world around me seem strange or unreal.")]
    public int? Unreal { get; set; }

    [Range(0, 4)]
    [Display(Name = "I find that I did things that I do not remember doing.")]
    public int? NoMemory { get; set; }

    [Range(0, 4)]
    [Display(Name = "When I am alone, I talk out loud to myself.")]
    public int? TalkOutLoud { get; set; }

    [Range(0, 4)]
    [Display(Name = "I feel as though I were looking at the world through a fog so that people and things seem far away or unclear.")]
    public int? Unclear { get; set; }

    [Range(0, 4)]
    [Display(Name = "I am able to ignore pain.")]
    public int? IgnorePain { get; set; }

    [Range(0, 4)]
    [Display(Name = "I act so differently from one situation to another that it is almost as if I were two different people.")]
    public int? DifferentPeople { get; set; }

    [Range(0, 4)]
    [Display(Name = "I can do things very easily that would usually be hard for me.")]
    public int? EasyWhenHard { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Nothing, Unreal, NoMemory, TalkOutLoud, Unclear, IgnorePain, DifferentPeople, EasyWhenHard
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserDissociativeSeverities))]
    public virtual User User { get; set; } = null!;
}
