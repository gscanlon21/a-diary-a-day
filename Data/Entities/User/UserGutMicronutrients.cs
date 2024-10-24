using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_micronutrients"), Comment("User variation weight log")]
public class UserGutMicronutrients
{
    public class Consts
    {
        public const double VitaminB3Min = 0;
        public const double VitaminB3Max = 100;
        public const double VitaminB3Step = .1;

        public const double VitaminB6Min = 0;
        public const double VitaminB6Max = 100;
        public const double VitaminB6Step = .1;

        public const double VitaminB9Min = 0;
        public const double VitaminB9Max = 100;
        public const double VitaminB9Step = .1;

        public const double VitaminB12Min = 0;
        public const double VitaminB12Max = 100;
        public const double VitaminB12Step = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 100)]
    [Display(Name = "Vitamin B3")]
    public double? VitaminB3 { get; set; }

    [Range(0, 100)]
    [Display(Name = "Vitamin B6")]
    public double? VitaminB6 { get; set; }

    [Range(0, 100)]
    [Display(Name = "Vitamin B9")]
    public double? VitaminB9 { get; set; }

    [Range(0, 100)]
    [Display(Name = "Vitamin B12")]
    public double? VitaminB12 { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(VitaminB3), VitaminB3 },
        { nameof(VitaminB6), VitaminB6 },
        { nameof(VitaminB9), VitaminB9 },
        { nameof(VitaminB12), VitaminB12 },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutMicronutrients))]
    public virtual User User { get; set; } = null!;
}
