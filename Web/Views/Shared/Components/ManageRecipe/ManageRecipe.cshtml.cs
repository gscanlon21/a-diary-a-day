using Core.Consts;
using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageRecipe;


public class ManageRecipeViewModel
{
    [ValidateNever]
    public required User.UserManageRecipeViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever]
    [Display(Name = "Recipe", Description = "Ignore this recipe.")]
    public required NewsletterTaskDto? Recipe { get; init; }

    [ValidateNever]
    [Display(Name = "Refreshes After", Description = "Refresh this recipe—the next feast will try and select a new recipe if available.")]
    public required UserTask UserRecipe { get; init; }

    [Display(Name = "Notes")]
    public string? Notes { get; init; }

    [Required, Range(UserConsts.LagRefreshXDaysMin, UserConsts.LagRefreshXDaysMax)]
    [Display(Name = "Lag Refresh by X Weeks", Description = "Add a delay before this recipe is recycled from your workouts.")]
    public int LagRefreshXDays { get; init; }

    [Required, Range(UserConsts.PadRefreshXDaysMin, UserConsts.PadRefreshXDaysMax)]
    [Display(Name = "Pad Refresh by X Weeks", Description = "Add a delay before this recipe is recirculated back into your workouts.")]
    public int PadRefreshXDays { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;
}
