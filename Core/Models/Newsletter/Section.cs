using Core.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Morning")]
    Morning = 1 << 0, // 1

    [Display(Name = "Midday")]
    Midday = 1 << 1, // 2

    [Display(Name = "Night")]
    Night = 1 << 2, // 4

    Debug = 1 << 15, // 32768
}

public static class SectionExtensions
{
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        Section.Morning => ExerciseTheme.Warmup,
        Section.Midday => ExerciseTheme.Cooldown,
        Section.Night => ExerciseTheme.Main,
        _ => ExerciseTheme.None,
    };
}