using Core.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
    None = 0,

    Debug = 1 << 15, // 32768
}

public static class SectionExtensions
{
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        _ => ExerciseTheme.None,
    };
}