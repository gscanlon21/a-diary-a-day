using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum CustomType
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Medicine")]
    Medicine = 1,

    [Display(Name = "Activity")]
    Activity = 2,

    [Display(Name = "Symptom")]
    Symptom = 3,

    [Display(Name = "People")]
    People = 5,

    [Display(Name = "Emotion")]
    Emotion = 6,

    [Display(Name = "Sleep")]
    Sleep = 7,
}
