﻿using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Views.Shared.Components.ManageTask;

public class ManageTaskViewModel
{
    public Section ManageSection { get; set; }

    public bool CompletedForSection { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    public string Token { get; init; } = null!;

    [ValidateNever]
    [Display(Name = "Task", Description = "Ignore this task.")]
    public NewsletterTaskDto? Task { get; init; }

    [ValidateNever]
    [Display(Name = "Refreshes After", Description = "Refresh this task and try to select a new task if available.")]
    public required UserTask UserTask { get; init; }


    /********** UserTask Properties **********/

    [Display(Name = "Name")]
    public string Name { get; init; } = null!;

    [Display(Name = "Notes")]
    public string? Notes { get; init; }

    [Display(Name = "Persist Until Complete")]
    public bool PersistUntilComplete { get; init; }

    [Required, Range(UserConsts.LagRefreshXDaysMin, UserConsts.LagRefreshXDaysMax)]
    [Display(Name = "Lag Refresh by X Days", Description = "Add a delay before this task is recycled from your task list.")]
    public int LagRefreshXDays { get; init; }

    [Required, Range(UserConsts.PadRefreshXDaysMin, UserConsts.PadRefreshXDaysMax)]
    [Display(Name = "Pad Refresh by X Days", Description = "Add a delay before this task is recirculated back into your task list.")]
    public int PadRefreshXDays { get; init; }

    [Required, Range(UserConsts.DeloadWeeksMin, UserConsts.DeloadWeeksMax)]
    [Display(Name = "Deload After Every X Weeks", Description = "After how many weeks of seeing a task do you want to take a deload week?")]
    public int DeloadAfterXWeeks { get; init; }

    [Required, Range(UserConsts.DeloadDurationMin, UserConsts.DeloadDurationMax)]
    [Display(Name = "Deload Duration (Weeks)", Description = "How long should deloads last?")]
    public int DeloadDurationWeeks { get; set; } = UserConsts.DeloadDurationDefault;

    /// <summary>
    /// This should be bound from the section binder, not the current section in query string.
    /// </summary>
    [BindNever]
    public Section Section { get; set; }

    [NotMapped]
    public Section[]? SectionBinder
    {
        get => Enum.GetValues<Section>().Where(e => Section.HasFlag(e)).ToArray();
        set => Section = value?.Aggregate(Section.None, (a, e) => a | e) ?? Section.None;
    }

    public string? DisabledReason { get; set; } = null;

    [NotMapped, Display(Name = "Enabled")]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
