﻿using Data.Entities.Footnote;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_symptom"), Comment("User variation weight log")]
public class UserSymptom
{
    public UserSymptom() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [JsonIgnore, InverseProperty(nameof(Entities.Footnote.UserCustom.UserSymptoms))]
    public virtual List<UserCustom> UserCustoms { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSymptoms))]
    public virtual User User { get; init; } = null!;
}
