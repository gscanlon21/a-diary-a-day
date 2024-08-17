using Core.Models.Newsletter;
using Data.Entities.Task;
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
    [HttpGet, Route("{section:section}/{taskId}")]
    public async Task<IActionResult> ManageTask(string email, string token, Section section, int taskId, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var task = await _context.UserTasks.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == taskId && r.UserId == user.Id);

        if (task == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(new UserManageTaskViewModel()
        {
            User = user,
            Task = task,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost, Route("{section:section}/{taskId}/complete-task")]
    public async Task<IActionResult> CompleteTask(string email, string token, Section section, int taskId)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return NotFound();
        }

        // Set the new weight on the UserVariation.
        var userTask = await _context.UserTasks.FirstAsync(p => p.UserId == user.Id && p.Id == taskId);
        userTask.LastCompleted = DateHelpers.Today;
        if (userTask.PersistUntilComplete)
        {
            await _newsletterRepo.UpdateLastSeenDate([userTask]);
        }

        var todaysUserLog = await _context.UserTaskLogs
            .Where(uw => uw.UserTaskId == userTask.Id)
            .Where(um => um.Section == section)
            .FirstOrDefaultAsync(uw => uw.Date == DateHelpers.Today);

        if (todaysUserLog != null)
        {
            todaysUserLog.Complete += 1;
        }
        else
        {
            _context.Add(new UserTaskLog()
            {
                UserTaskId = userTask.Id,
                Date = DateHelpers.Today,
                Section = section,
                Complete = 1,
            });
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{taskId}/refresh-task")]
    public async Task<IActionResult> RefreshTask(string email, string token, Section section, int taskId)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await _context.UserTasks
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.Id == taskId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userProgression.RefreshAfter = null;
        userProgression.LastSeen = userProgression.LastSeen > DateHelpers.Today ? DateHelpers.Today : userProgression.LastSeen;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{taskId}/upsert-task", Order = 1)]
    [Route("{taskId}/upsert-task", Order = 2)]
    public async Task<IActionResult> UpsertTask(string email, string token, int taskId, ManageTaskViewModel viewModel, Section? section = null)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = false });
        }

        var user = await _userRepo.GetUser(email, token, allowDemoUser: taskId != default);
        if (user == null)
        {
            return NotFound();
        }

        if (taskId == default)
        {
            // Adding task.
            _context.Add(new Data.Entities.Task.UserTask()
            {
                User = user,
                Name = viewModel.Name,
                Notes = viewModel.Notes,
                Section = viewModel.Section,
                Enabled = viewModel.Enabled,
                PadRefreshXDays = viewModel.PadRefreshXDays,
                LagRefreshXDays = viewModel.LagRefreshXDays,
                DeloadAfterXWeeks = viewModel.DeloadAfterXWeeks,
                PersistUntilComplete = viewModel.PersistUntilComplete,
            });

            await _context.SaveChangesAsync();
            TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
            return RedirectToAction(nameof(Edit), new { email, token });
        }
        else
        {
            var userTask = await _context.UserTasks
                .FirstAsync(p => p.UserId == user.Id && p.Id == taskId);

            // Apply refresh padding immediately.
            if (viewModel.PadRefreshXDays != userTask.PadRefreshXDays)
            {
                var difference = viewModel.PadRefreshXDays - userTask.PadRefreshXDays; // 11 new - 1 old = 10 weeks.
                userTask.LastSeen = userTask.LastSeen.AddDays(difference); // Add 70 days onto the LastSeen date.
            }

            userTask.Name = user.IsDemoUser ? userTask.Name : viewModel.Name;
            userTask.PersistUntilComplete = viewModel.PersistUntilComplete;
            userTask.Notes = user.IsDemoUser ? null : viewModel.Notes;
            userTask.DeloadAfterXWeeks = viewModel.DeloadAfterXWeeks;
            userTask.LagRefreshXDays = viewModel.LagRefreshXDays;
            userTask.PadRefreshXDays = viewModel.PadRefreshXDays;
            userTask.Section = viewModel.Section;
            userTask.Enabled = viewModel.Enabled;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = true });
        }
    }

    [HttpPost, Route("delete-task")]
    public async Task<IActionResult> RemoveTask(string email, string token, Section section, [FromForm] int taskId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await _context.UserTasks
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == taskId)
            .ExecuteDeleteAsync();

        TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
        return RedirectToAction(nameof(Edit), new { email, token });
    }
}
