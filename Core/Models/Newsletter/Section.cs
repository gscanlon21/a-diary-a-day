﻿using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "Anytime")]
    Anytime = 0,

    [Display(Name = "After Waking Up")]
    AfterWakingUp = 1 << 0, // 1

    [Display(Name = "Before Breakfast")]
    BeforeBreakfast = 1 << 1, // 2

    [Display(Name = "With Breakfast")]
    WithBreakfast = 1 << 2, // 4

    [Display(Name = "After Breakfast")]
    AfterBreakfast = 1 << 3, // 8

    [Display(Name = "Before Lunch")]
    BeforeLunch = 1 << 4, // 16

    [Display(Name = "With Lunch")]
    WithLunch = 1 << 5, // 32

    [Display(Name = "After Lunch")]
    AfterLunch = 1 << 6, // 64

    [Display(Name = "Before Dinner")]
    BeforeDinner = 1 << 7, // 128

    [Display(Name = "With Dinner")]
    WithDinner = 1 << 8, // 256

    [Display(Name = "After Dinner")]
    AfterDinner = 1 << 9, // 512

    [Display(Name = "Pre-Workout")]
    PreWorkout = 1 << 10, // 1024

    [Display(Name = "Post-Workout")]
    PostWorkout = 1 << 11, // 2048

    [Display(Name = "Before Bed")]
    BeforeBed = 1 << 12, // 4096

    [Display(Name = "Any Day")]
    AnyDay = 1 << 13, // 8192

    All = AfterWakingUp | BeforeBreakfast | WithBreakfast | AfterBreakfast
        | BeforeLunch | WithLunch | AfterLunch
        | BeforeDinner | WithDinner | AfterDinner
        | PreWorkout | PostWorkout | BeforeBed
        | AnyDay,
}

public static class SectionExtensions
{
    public static Theme AsTheme(this Section section) => section switch
    {
        Section.AfterWakingUp or Section.BeforeBed => Theme.Warmup,
        Section.BeforeBreakfast or Section.WithBreakfast or Section.AfterBreakfast => Theme.Other,
        Section.BeforeLunch or Section.WithLunch or Section.AfterLunch => Theme.Extra,
        Section.BeforeDinner or Section.WithDinner or Section.AfterDinner => Theme.Cooldown,
        Section.PreWorkout or Section.PostWorkout => Theme.Main,
        Section.Anytime or Section.AnyDay => Theme.None,
        _ => Theme.None,
    };
}