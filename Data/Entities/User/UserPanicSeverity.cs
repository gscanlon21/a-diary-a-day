using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/6ab8ea4f-e810-4c0c-b41c-16838293506d/APA-DSM5TR-SeverityMeasureForPanicDisorderAdult.pdf
/// </summary>
[Table("user_panic_severity"), Comment("User variation weight log")]
public class UserPanicSeverity
{
    public UserPanicSeverity() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? ProratedScore => Items.Count * Items.Sum() / Items.Count(d => d.HasValue);

    /// <summary>
    /// Prorated score.
    /// </summary>
    [Range(0, 99)]
    public int? AverageScore => Items.Count(d => d.HasValue) == Items.Count ? Items.Sum() / Items.Count : null;

    [Range(0, 4)]
    [Display(Name = "felt moments of sudden terror, fear or fright, sometimes out of the blue (i.e., a panic attack")]
    public int? SuddenTerror { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt anxious, worried, or nervous about having more panic attacks")]
    public int? Nervous { get; set; }

    [Range(0, 4)]
    [Display(Name = "had thoughts of losing control, dying, going crazy, or other bad things happening because of panic attack")]
    public int? LosingControl { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt a racing heart, sweaty, trouble breathing, faint, or shaky")]
    public int? Heart { get; set; }

    [Range(0, 4)]
    [Display(Name = "felt tense muscles, felt on edge or restless, or had trouble relaxing or trouble sleeping")]
    public int? Tense { get; set; }

    [Range(0, 4)]
    [Display(Name = "avoided, or did not approach or enter, situations in which panic attacks might occu")]
    public int? Avoided { get; set; }

    [Range(0, 4)]
    [Display(Name = "left situations early, or participated only minimally, because of panic attacks")]
    public int? LeftEarly { get; set; }

    [Range(0, 4)]
    [Display(Name = "spent a lot of time preparing for, or procrastinating about (putting off), situations in which panic attacks might occur")]
    public int? Preparing { get; set; }

    [Range(0, 4)]
    [Display(Name = "distracted myself to avoid thinking about panic attack")]
    public int? DistractedMyself { get; set; }

    [Range(0, 4)]
    [Display(Name = "needed help to cope with panic attacks (e.g., alcohol or medication, superstitious objects, other people)")]
    public int? Cope { get; set; }

    [NotMapped]
    public List<int?> Items => new()
    {
        Cope, DistractedMyself, Preparing, LeftEarly, Avoided, Tense, Heart, LosingControl, SuddenTerror, Nervous
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserPanicSeverities))]
    public virtual User User { get; set; } = null!;
}
