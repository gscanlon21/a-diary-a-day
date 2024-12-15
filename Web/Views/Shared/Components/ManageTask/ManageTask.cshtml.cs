using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Views.Shared.Components.ManageTask;

public class ManageTaskViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public ManageTaskViewModel() { }

    public ManageTaskViewModel(Data.Entities.User.User user, UserTask userTask, string token)
    {
        User = user;
        Token = token;
        UserTask = userTask;
        Type = userTask.Type;
        Name = userTask.Name;
        Notes = userTask.Notes;
        Order = userTask.Order;
        ShowLog = userTask.ShowLog;
        Section = userTask.Section;
        ReferenceMin = userTask.ReferenceMin;
        ReferenceMax = userTask.ReferenceMax;
        InternalNotes = userTask.InternalNotes;
        DisabledReason = userTask.DisabledReason;
        LagRefreshXDays = userTask.LagRefreshXDays;
        PadRefreshXDays = userTask.PadRefreshXDays;
        PersistUntilComplete = userTask.PersistUntilComplete;
        DeloadAfterXWeeks = userTask.DeloadAfterXWeeks;
        DeloadDurationWeeks = userTask.DeloadDurationWeeks;
    }

    [ValidateNever]
    public Data.Entities.User.User User { get; init; } = null!;

    [ValidateNever]
    public string Token { get; init; } = null!;

    [ValidateNever]
    public Section ManageSection { get; init; }

    [ValidateNever]
    public bool CompletedForSection { get; init; }

    [ValidateNever]
    [Display(Name = "Refreshes After", Description = "Refresh this task and try to select a new task if available.")]
    public UserTask UserTask { get; init; } = null!;


    /********** UserTask Properties **********/

    [Display(Name = "Name")]
    public string Name { get; init; } = null!;

    [Display(Name = "Type")]
    public UserTaskType Type { get; init; }

    [Display(Name = "Notes")]
    public string? Notes { get; init; }

    [Display(Name = "Internal Notes")]
    public string? InternalNotes { get; init; }

    [Display(Name = "Order")]
    [Range(UserTask.Consts.OrderMin, UserTask.Consts.OrderMax)]
    public int Order { get; init; } = UserTask.Consts.OrderDefault;

    [Display(Name = "Show Log")]
    public bool ShowLog { get; init; }

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

    [ValidateNever]
    [Display(Name = "Reference Range (Min)", Description = "")]
    public double? ReferenceMin { get; init; }

    [ValidateNever]
    [Display(Name = "Reference Range (Max)", Description = "")]
    public double? ReferenceMax { get; set; }

    [ValidateNever]
    [Display(Name = "Value", Description = "")]
    public double Value { get; set; }


    /// <summary>
    /// This should be bound from the section binder, not the current section in query string.
    /// </summary>
    [BindNever]
    public Section Section { get; set; }

    [NotMapped]
    public Section[]? SectionBinder
    {
        get => Enum.GetValues<Section>().Where(e => Section.HasFlag(e)).ToArray();
        set => Section = value?.Aggregate(Section.Anytime, (a, e) => a | e) ?? Section.Anytime;
    }

    public string? DisabledReason { get; set; } = null;

    [NotMapped, Display(Name = "Enabled")]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
