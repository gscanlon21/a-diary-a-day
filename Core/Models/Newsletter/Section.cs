using Core.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "Anytime")]
    None = 0,

    [Display(Name = "Morning")]
    Morning = 1 << 0, // 1

    [Display(Name = "Midday")]
    Midday = 1 << 1, // 2

    [Display(Name = "Afternoon")]
    Afternoon = 1 << 2, // 4

    [Display(Name = "Night")]
    Night = 1 << 3, // 8

    Debug = 1 << 15, // 32768
}

public static class SectionExtensions
{
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        Section.Morning => ExerciseTheme.Other,
        Section.Midday => ExerciseTheme.Extra,
        Section.Afternoon => ExerciseTheme.Cooldown,
        Section.Night => ExerciseTheme.Main,
        Section.None => ExerciseTheme.Warmup,
        _ => ExerciseTheme.None,
    };
}