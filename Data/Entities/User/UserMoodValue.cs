using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User
{

    /// <summary>
    /// User's progression level of an exercise.
    /// 
    /// TODO Scopes.
    /// TODO Single-use tokens.
    /// </summary>
    [Table("user_mood_value"), Comment("User variation weight log")]
    public class UserMoodValue
    {
        public UserMoodValue() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private init; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int UserMoodId { get; set; }

        /// <summary>
        /// The token should stop working after this date.
        /// </summary>
        [Required]
        public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [JsonIgnore, InverseProperty(nameof(Newsletter.UserMood.UserVariationWeights))]
        public virtual UserMood UserMood { get; private init; } = null!;
    }

}
