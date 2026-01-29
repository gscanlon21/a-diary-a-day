using Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_micronutrients")]
[Display(Name = "Micronutrients", Description = "The list of micronutrients below reflects your gut's capability to produce the following B vitamins based on the bacteria present.")]
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

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.VitaminB3Min, Consts.VitaminB3Max)]
    [Display(Name = "Vitamin B3", Description = "Vitamin B3 (niacin), like all B vitamins, plays an important role in metabolizing food. It aids nervous system function, supports hormone production, and improves circulation and cholesterol levels. Symptoms of a mild niacin deficiency include depression, fatigue, indigestion, vomiting, and canker sores. In developed countries, the most common causes of deficiency are alcohol consumption and malabsorption disorders in the gut.")]
    public double? VitaminB3 { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.VitaminB6Min, Consts.VitaminB6Max)]
    [Display(Name = "Vitamin B6", Description = "Vitamin B6 is a versatile micronutrient that performs many different functions in your body, including digesting protein and producing new blood cells and immune system cells. A mild vitamin B6 deficiency might not exhibit symptoms for months or even years. Symptoms of a severe deficiency can include anemia, scaling on the mouth, swollen tongue, depression, confusion, and a weakened immune system. Deficiencies can be caused by kidney diseases and gut malabsorption disorders, such as celiac disease or Crohn's disease.")]
    public double? VitaminB6 { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.VitaminB9Min, Consts.VitaminB9Max)]
    [Display(Name = "Vitamin B9", Description = "Vitamin B9 (folate) is necessary for energy metabolism and proper cell division. A folate deficiency can be caused by poor diet, alcohol abuse, certain medications, and gut malabsorption disorders, such as celiac disease and inflammatory bowel disease. Symptoms of a deficiency can include anemia, weakness, fatigue, difficulty concentrating, irritability, headache, heart palpitations, shortness of breath, mouth ulcers, and changes in hair or skin pigmentation.")]
    public double? VitaminB9 { get; set; }

    [IdealRange(0, 33, RiskType.HighRisk)]
    [IdealRange(33, 66, RiskType.ModerateRisk)]
    [IdealRange(66, 100, RiskType.LowRisk)]
    [Range(Consts.VitaminB12Min, Consts.VitaminB12Max)]
    [Display(Name = "Vitamin B12", Description = "Vitamin B12 keeps your body's nervous system healthy, as well as playing a role in digesting protein and making DNA and red blood cells. Malabsorption disorders, such as hypochlorhydria (low stomach acid), celiac disease, and IBD, can result in a vitamin B12 deficiency. Individuals who avoid animal products are also at risk of a B12 deficiency. Certain medications also contribute to vitamin B12 depletion.  A vitamin B12 deficiency can manifest as neurological symptoms, such as numbness or tingling in the hands, legs, and feet, difficulty walking, and confusion or difficulty thinking. Other symptoms can include anemia, weakness and fatigue, constipation, and a swollen tongue. A vitamin B12 deficiency can lead to permanent nerve and brain damage and increase the risk of dementia.")]
    public double? VitaminB12 { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(VitaminB3), VitaminB3 },
        { nameof(VitaminB6), VitaminB6 },
        { nameof(VitaminB9), VitaminB9 },
        { nameof(VitaminB12), VitaminB12 },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserGutMicronutrients))]
    public virtual User User { get; set; } = null!;
}
