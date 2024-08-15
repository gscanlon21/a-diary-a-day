using Core.Code.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.Shared.Components.UpsertTask;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("{taskId}", Order = 1)]
    public async Task<IActionResult> ManageRecipe(string email, string token, int taskId, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var task = await context.UserTasks.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == taskId && r.UserId == user.Id);

        if (task == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(new UserManageTaskViewModel()
        {
            User = user,
            Task = task,
            WasUpdated = wasUpdated,
            Parameters = new UserManageTaskViewModel.Params(email, token, taskId)
        });
    }

    [HttpPost, Route("task/upsert")]
    public async Task<IActionResult> UpsertTask(string email, string token, UpsertTaskModel task)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (task.Id == default)
        {
            if (ModelState.IsValid)
            {
                // Adding recipe.
                context.Add(new Data.Entities.Task.UserTask()
                {
                    User = user,
                    Name = task.Name,
                    Notes = task.Notes,
                    Enabled = task.Enabled,
                });

                await context.SaveChangesAsync();
                TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
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
                    .FirstOrDefaultAsync(r => r.Id == task.Id && r.UserId == user.Id);
                if (existingRecipe == null)
                {
                    return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
                }

                existingRecipe.Name = task.Name;
                existingRecipe.Notes = task.Notes;
                existingRecipe.Enabled = task.Enabled;

                await context.SaveChangesAsync();
                TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
                return RedirectToAction(nameof(ManageRecipe), new { email, token, taskId = task.Id, wasUpdated = true });
            }

            return await ManageRecipe(email, token, task.Id, wasUpdated: false);
        }
    }

    [HttpPost, Route("recipe/remove")]
    public async Task<IActionResult> RemoveRecipe(string email, string token, [FromForm] int taskId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserTasks
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == taskId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
        return RedirectToAction(nameof(Edit), new { email, token });
    }


    [HttpPost]
    [Route("{taskId}/ir", Order = 1)]
    [Route("{taskId}/ignore-recipe", Order = 2)]
    public async Task<IActionResult> IgnoreRecipe(string email, string token, int taskId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserTasks
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.Id == taskId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        //userProgression.Ignore = !userProgression.Ignore;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, taskId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{taskId}/rr", Order = 1)]
    [Route("{taskId}/refresh-recipe", Order = 2)]
    public async Task<IActionResult> RefreshRecipe(string email, string token, int taskId)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserTasks
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.Id == taskId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userProgression.RefreshAfter = null;
        userProgression.LastSeen = userProgression.LastSeen > DateHelpers.Today ? DateHelpers.Today : userProgression.LastSeen;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, taskId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{taskId}/l", Order = 1)]
    [Route("{taskId}/log", Order = 2)]
    public async Task<IActionResult> LogRecipe(string email, string token, int taskId, ManageTaskViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var userRecipe = await context.UserTasks
                .FirstAsync(p => p.UserId == user.Id && p.Id == taskId);

            // Apply refresh padding immediately.
            if (viewModel.PadRefreshXDays != userRecipe.PadRefreshXDays)
            {
                var difference = viewModel.PadRefreshXDays - userRecipe.PadRefreshXDays; // 11 new - 1 old = 10 weeks.
                userRecipe.LastSeen = userRecipe.LastSeen.AddDays(difference); // Add 70 days onto the LastSeen date.
            }

            userRecipe.LagRefreshXDays = viewModel.LagRefreshXDays;
            userRecipe.PadRefreshXDays = viewModel.PadRefreshXDays;
            userRecipe.Notes = user.IsDemoUser ? null : viewModel.Notes;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageRecipe), new { email, token, taskId, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageRecipe), new { email, token, taskId, WasUpdated = false });
    }
}
