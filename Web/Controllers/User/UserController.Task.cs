using Core.Code.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.Shared.Components.UpsertRecipe;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("{recipeId}", Order = 1)]
    public async Task<IActionResult> ManageRecipe(string email, string token, int recipeId, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var recipe = await context.UserTasks.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == recipeId && r.UserId == user.Id);

        if (recipe == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(new UserManageRecipeViewModel()
        {
            User = user,
            WasUpdated = wasUpdated,
            Recipe = recipe,
            Parameters = new UserManageRecipeViewModel.Params(email, token, recipeId)
        });
    }

    [HttpPost, Route("recipe/upsert")]
    public async Task<IActionResult> UpsertRecipe(string email, string token, UpsertRecipeModel recipe)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (recipe.Id == default)
        {
            if (ModelState.IsValid)
            {
                // Adding recipe.
                context.Add(new Data.Entities.Task.UserTask()
                {
                    User = user,
                    Name = recipe.Name,
                    Notes = recipe.Notes,
                    Enabled = recipe.Enabled,
                });

                await context.SaveChangesAsync();
                TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
                return RedirectToAction(nameof(Edit), new { email, token });
            }

            return await Edit(email, token);
        }
        else
        {
            if (ModelState.IsValid)
            {
                // Editing recipe.
                var existingRecipe = await context.UserTasks
                    .FirstOrDefaultAsync(r => r.Id == recipe.Id && r.UserId == user.Id);
                if (existingRecipe == null)
                {
                    return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
                }

                existingRecipe.Name = recipe.Name;
                existingRecipe.Notes = recipe.Notes;
                existingRecipe.Enabled = recipe.Enabled;

                await context.SaveChangesAsync();
                TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
                return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId = recipe.Id, wasUpdated = true });
            }

            return await ManageRecipe(email, token, recipe.Id, wasUpdated: false);
        }
    }

    [HttpPost, Route("recipe/remove")]
    public async Task<IActionResult> RemoveRecipe(string email, string token, [FromForm] int recipeId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserTasks
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == recipeId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }


    [HttpPost]
    [Route("{recipeId}/ir", Order = 1)]
    [Route("{recipeId}/ignore-recipe", Order = 2)]
    public async Task<IActionResult> IgnoreRecipe(string email, string token, int recipeId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserTasks
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.Id == recipeId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        //userProgression.Ignore = !userProgression.Ignore;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{recipeId}/rr", Order = 1)]
    [Route("{recipeId}/refresh-recipe", Order = 2)]
    public async Task<IActionResult> RefreshRecipe(string email, string token, int recipeId)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserTasks
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.Id == recipeId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userProgression.RefreshAfter = null;
        userProgression.LastSeen = userProgression.LastSeen > DateHelpers.Today ? DateHelpers.Today : userProgression.LastSeen;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{recipeId}/l", Order = 1)]
    [Route("{recipeId}/log", Order = 2)]
    public async Task<IActionResult> LogRecipe(string email, string token, int recipeId, ManageRecipeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var userRecipe = await context.UserTasks
                .FirstAsync(p => p.UserId == user.Id && p.Id == recipeId);

            // Apply refresh padding immediately.
            if (viewModel.PadRefreshXWeeks != userRecipe.PadRefreshXWeeks)
            {
                var difference = viewModel.PadRefreshXWeeks - userRecipe.PadRefreshXWeeks; // 11 new - 1 old = 10 weeks.
                userRecipe.LastSeen = userRecipe.LastSeen.AddDays(7 * difference); // Add 70 days onto the LastSeen date.
            }

            userRecipe.LagRefreshXWeeks = viewModel.LagRefreshXWeeks;
            userRecipe.PadRefreshXWeeks = viewModel.PadRefreshXWeeks;
            userRecipe.Notes = user.IsDemoUser ? null : viewModel.Notes;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, WasUpdated = false });
    }
}
