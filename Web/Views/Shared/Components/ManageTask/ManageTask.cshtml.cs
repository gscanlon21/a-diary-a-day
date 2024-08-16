using Core.Consts;
using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageRecipe;

public class ManageTaskViewModel
{
    public string Token { get; init; } = null!;

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever]
    [Display(Name = "Task", Description = "Ignore this task.")]
    public NewsletterTaskDto? Task { get; init; }

    [ValidateNever]
    [Display(Name = "Refreshes After", Description = "Refresh this task and try to select a new task if available.")]
    public required UserTask UserTask { get; init; }


    [Display(Name = "Name")]
    public string Name { get; init; } = null!;

    [Display(Name = "Notes")]
    public string? Notes { get; init; }

    [Required, Range(UserConsts.LagRefreshXDaysMin, UserConsts.LagRefreshXDaysMax)]
    [Display(Name = "Lag Refresh by X Days", Description = "Add a delay before this task is recycled from your task list.")]
    public int LagRefreshXDays { get; init; }

    [Required, Range(UserConsts.PadRefreshXDaysMin, UserConsts.PadRefreshXDaysMax)]
    [Display(Name = "Pad Refresh by X Days", Description = "Add a delay before this task is recirculated back into your task list.")]
    public int PadRefreshXDays { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;

    public bool Enabled => true;
}
