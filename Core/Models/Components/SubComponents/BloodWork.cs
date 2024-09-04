using System.ComponentModel.DataAnnotations;

namespace Core.Models.Components.SubComponents;

[Flags]
public enum BloodWork
{
    None = 0,

    [Display(Name = "Homocysteine")]
    Homocysteine = 1 << 0, // 1

    [Display(Name = "Vitamin A (Retinol)", ShortName = "Vitamin A")]
    VitaminA = 1 << 1, // 2

    All = Homocysteine | VitaminA,
}
