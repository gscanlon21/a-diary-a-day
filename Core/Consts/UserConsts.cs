﻿using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;

namespace Core.Consts;

/// <summary>
/// Shared user consts for Functions and Web.
/// </summary>
public class UserConsts
{
    public const string DemoUser = "demo@adiaryaday.com";
    public const string DemoToken = "00000000-0000-0000-0000-000000000000";

    /// <summary>
    /// Since we upload an image for each task, let's limit it to keep costs low.
    /// </summary>
    public const int MaxTasks = 256;

    public const int ChartDaysMin = 30;
    public const int ChartDaysStep = 30;
    public const int ChartDaysDefault = 360;
    public const int ChartDaysMax = 990;

    public const int SendHourMin = 0;
    public const int SendHourDefault = 0;
    public const int SendHourMax = 23;

    public const int UserMuscleMobilityMin = 0;
    public const int UserMuscleMobilityMax = 3;

    public const int UserMuscleFlexibilityMin = 0;
    public const int UserMuscleFlexibilityMax = 3;

    public const int LagRefreshXDaysMin = 0;
    public const int LagRefreshXDaysDefault = 0;
    public const int LagRefreshXDaysMax = 365;

    public const int PadRefreshXDaysMin = 0;
    public const int PadRefreshXDaysDefault = 0;
    public const int PadRefreshXDaysMax = 365;

    public const int DeloadWeeksMin = 0;
    public const int DeloadWeeksDefault = 0;
    public const int DeloadWeeksMax = 52;

    public const int DeloadDurationMin = 1;
    public const int DeloadDurationDefault = 1;
    public const int DeloadDurationMax = 4;

    public const int UserTaskCompleteMin = 0;
    public const int UserTaskCompleteDefault = 0;
    public const int UserTaskCompleteMax = 10;

    public const Days DaysDefault = Days.Monday | Days.Tuesday | Days.Thursday | Days.Friday;

    public const Verbosity VerbosityDefault = Verbosity.Images | Verbosity.Notes;

    public const FootnoteType FootnotesDefault = FootnoteType.HealthTips | FootnoteType.HealthFacts | FootnoteType.GoodVibes | FootnoteType.Mindfulness;

    /// <summary>
    /// After how many weeks until muscle targets start taking effect.
    /// </summary>
    public const int MuscleTargetsTakeEffectAfterXWeeks = 1;

    /// <summary>
    /// The lowest the user's progression can go.
    /// 
    /// Also the user's starting progression when the user is new to fitness.
    /// </summary>
    public const int MinUserProgression = 5;

    /// <summary>
    /// Also the user's starting progression when the user is not new to fitness.
    /// </summary>
    public const int MidUserProgression = 50;

    /// <summary>
    /// The highest the user's progression can go.
    /// </summary>
    public const int MaxUserProgression = 95;

    /// <summary>
    /// How many custom user_frequency records do we allow per user?
    /// </summary>
    public const int MaxUserFrequencies = 7;

    /// <summary>
    /// How much to increment the user_muscle_strength target ranges with each increment?
    /// </summary>
    public const int IncrementMuscleTargetBy = 10;

    /// <summary>
    /// How many months until the user's account is disabled for inactivity.
    /// </summary>
    public const int DisableAfterXMonths = 3;

    /// <summary>
    /// How many months until the user's account is deleted for inactivity.
    /// </summary>
    public const int DeleteAfterXMonths = 6;

    /// <summary>
    /// How many months until the user's diary entries are deleted.
    /// </summary>
    public const int DeleteEntriesAfterXMonths = 12;

    /// <summary>
    /// How many months until the user's task logs are deleted.
    /// </summary>
    public const int DeleteLogsAfterXMonths = 60;
}
