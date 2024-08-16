using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet, Route("{taskId}", Order = 1)]
    public async Task<IActionResult> ManageTask(string email, string token, int taskId, bool? wasUpdated = null)
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
        });
    }

    [HttpPost, Route("task/remove")]
    public async Task<IActionResult> RemoveTask(string email, string token, [FromForm] int taskId)
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

        return RedirectToAction(nameof(ManageTask), new { email, token, taskId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{taskId}/l", Order = 1)]
    [Route("{taskId}/log", Order = 2)]
    public async Task<IActionResult> UpsertTask(string email, string token, int taskId, ManageTaskViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(ManageTask), new { email, token, taskId, WasUpdated = false });
        }

        var user = await userRepo.GetUser(email, token, allowDemoUser: taskId != default);
        if (user == null)
        {
            return NotFound();
        }

        if (taskId == default)
        {
            // Adding task.
            context.Add(new Data.Entities.Task.UserTask()
            {
                User = user,
                Name = viewModel.Name,
                Notes = viewModel.Notes,
                Section = viewModel.Section,
                Enabled = viewModel.Enabled,
                PadRefreshXDays = viewModel.PadRefreshXDays,
                LagRefreshXDays = viewModel.LagRefreshXDays,
            });

            await context.SaveChangesAsync();
            TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
            return RedirectToAction(nameof(Edit), new { email, token });
        }
        else
        {
            var userTask = await context.UserTasks
                .FirstAsync(p => p.UserId == user.Id && p.Id == taskId);

            // Apply refresh padding immediately.
            if (viewModel.PadRefreshXDays != userTask.PadRefreshXDays)
            {
                var difference = viewModel.PadRefreshXDays - userTask.PadRefreshXDays; // 11 new - 1 old = 10 weeks.
                userTask.LastSeen = userTask.LastSeen.AddDays(difference); // Add 70 days onto the LastSeen date.
            }

            userTask.Name = user.IsDemoUser ? userTask.Name : viewModel.Name;
            userTask.Notes = user.IsDemoUser ? null : viewModel.Notes;
            userTask.LagRefreshXDays = viewModel.LagRefreshXDays;
            userTask.PadRefreshXDays = viewModel.PadRefreshXDays;
            userTask.Section = viewModel.Section;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageTask), new { email, token, taskId, WasUpdated = true });
        }
    }
}
