using Core.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "Anytime")]
    None = 0,

    [Display(Name = "Before Breakfast")]
    BeforeBreakfast = 1 << 0, // 1

    [Display(Name = "With Breakfast")]
    WithBreakfast = 1 << 1, // 2

    [Display(Name = "After Breakfast")]
    AfterBreakfast = 1 << 2, // 4

    [Display(Name = "Morning")]
    Morning = 1 << 3, // 8

    [Display(Name = "Before Lunch")]
    BeforeLunch = 1 << 4, // 16

    [Display(Name = "With Lunch")]
    WithLunch = 1 << 5, // 32

    [Display(Name = "After Lunch")]
    AfterLunch = 1 << 6, // 64

    [Display(Name = "Midday")]
    Midday = 1 << 7, // 128

    [Display(Name = "Afternoon")]
    Afternoon = 1 << 8, // 256

    [Display(Name = "Before Dinner")]
    BeforeDinner = 1 << 9, // 512

    [Display(Name = "With Dinner")]
    WithDinner = 1 << 10, // 1024

    [Display(Name = "After Dinner")]
    AfterDinner = 1 << 11, // 2048

    [Display(Name = "Evening")]
    Evening = 1 << 12, // 4096

    [Display(Name = "Before Bed")]
    BeforeBed = 1 << 13, // 8192

    [Display(Name = "Pre-Workout")]
    PreWorkout = 1 << 14, // 16384

    [Display(Name = "Post-Workout")]
    PostWorkout = 1 << 15, // 32768

    All = Morning | Midday | Afternoon | PreWorkout | PostWorkout | BeforeBed,
}

public static class SectionExtensions
{
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        Section.Morning or Section.BeforeBreakfast or Section.WithBreakfast or Section.AfterBreakfast => ExerciseTheme.Other,
        Section.Midday or Section.BeforeLunch or Section.WithLunch or Section.AfterLunch or Section.Afternoon => ExerciseTheme.Extra,
        Section.Evening or Section.BeforeDinner or Section.WithDinner or Section.AfterDinner => ExerciseTheme.Cooldown,
        Section.BeforeBed => ExerciseTheme.Main or Section.PreWorkout or Section.PostWorkout,
        Section.None => ExerciseTheme.Warmup,
        _ => ExerciseTheme.None,
    };
}