using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.ManageTask;
using Web.Views.User;
using static Data.Entities.Users.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Task.
    /// </summary>
    [HttpGet, Route("{section:section}/{taskId}")]
    public async Task<IActionResult> ManageTask(string email, string token, Section section, int taskId, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, Includes.Settings, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var admin = user.Features.HasFlag(Features.Admin);
        var task = await _context.UserTasks.AsNoTracking().IgnoreQueryFilters()
            .Where(ut => ut.UserId == user.Id || (ut.UserId == null && admin))
            .Where(ut => ut.Id == taskId)
            .FirstOrDefaultAsync();

        if (task == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(new UserManageTaskViewModel()
        {
            User = user,
            Task = task,
            Token = token,
            Section = section,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost, Route("{section:section}/{taskId}/show-task-log")]
    public async Task<IActionResult> ShowTaskLog(string email, string token, Section section, int taskId, UserTask task)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return NotFound();
        }

        // Set the last completed date on the UserTask.
        var userTask = await _context.UserTasks.FirstAsync(ut => ut.UserId == user.Id && ut.Id == taskId);
        userTask.ChartDays = task.ChartDays;
        userTask.ShowLog = task.ShowLog;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{taskId}/complete-task")]
    public async Task<IActionResult> CompleteTask(string email, string token, Section section, int taskId, double value = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return NotFound();
        }

        // Set the last completed date on the UserTask.
        var userTask = await _context.UserTasks.FirstAsync(ut => ut.UserId == user.Id && ut.Id == taskId);
        userTask.LastCompleted = DateHelpers.Today;
        if (userTask.PersistUntilComplete)
        {
            // Update the refresh dates if we were waiting for task completion.
            await _newsletterRepo.UpdateLastSeenDate([userTask]);
        }

        var todaysUserLog = await _context.UserTaskLogs
            .Where(uw => uw.UserTaskId == userTask.Id)
            .Where(um => um.Section == section)
            .FirstOrDefaultAsync(uw => uw.Date == DateHelpers.Today);

        if (todaysUserLog != null)
        {
            if (userTask.Type == UserTaskType.Log)
            {
                todaysUserLog.Complete = value;
            }
            else
            {
                todaysUserLog.Complete += value;
            }
        }
        else
        {
            _context.Add(new UserTaskLog(user, userTask)
            {
                Section = section,
                Complete = value,
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

        var userTask = await _context.UserTasks
            .FirstOrDefaultAsync(ut => ut.UserId == user.Id && ut.Id == taskId);

        // May be null if the task was soft/hard deleted
        if (userTask == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userTask.RefreshAfter = null;
        userTask.LastSeen = userTask.LastSeen > DateHelpers.Today ? DateHelpers.Today : userTask.LastSeen;
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

        // Limit the number of tasks that can be created.
        if ((await _context.UserTasks.CountAsync(ut => ut.UserId == user.Id)) >= UserConsts.MaxTasks)
        {
            TempData[TempData_User.FailureMessage] = "Max tasks reached.";
            return RedirectToAction(nameof(ManageTask), new { email, token, section, taskId, WasUpdated = false });
        }

        if (taskId == default)
        {
            // Adding task.
            _context.Add(new UserTask()
            {
                User = user,
                Type = viewModel.Type,
                Name = viewModel.Name,
                Notes = viewModel.Notes,
                Order = viewModel.Order,
                Source = viewModel.Source,
                Section = viewModel.Section,
                Enabled = viewModel.Enabled,
                PadRefreshXDays = viewModel.PadRefreshXDays,
                LagRefreshXDays = viewModel.LagRefreshXDays,
                DeloadAfterXWeeks = viewModel.DeloadAfterXWeeks,
                DeloadDurationWeeks = viewModel.DeloadDurationWeeks,
                PersistUntilComplete = viewModel.PersistUntilComplete,
            });

            await _context.SaveChangesAsync();
            TempData[TempData_User.SuccessMessage] = "Your tasks have been updated!";
            return RedirectToAction(nameof(Edit), new { email, token });
        }
        else
        {
            var userTask = await _context.UserTasks
                .FirstAsync(ut => ut.UserId == user.Id && ut.Id == taskId);

            // Apply refresh padding immediately.
            if (viewModel.PadRefreshXDays != userTask.PadRefreshXDays && userTask.LastSeen > DateOnly.MinValue)
            {
                var difference = viewModel.PadRefreshXDays - userTask.PadRefreshXDays; // 9 new - 1 old = 8 days.
                userTask.LastSeen = userTask.LastSeen?.AddDays(difference); // Add 70 days onto the LastSeen date.
            }

            // Apply refresh lagging immediately.
            if (viewModel.LagRefreshXDays != userTask.LagRefreshXDays)
            {
                var difference = viewModel.LagRefreshXDays - userTask.LagRefreshXDays; // 11 new - 2 old = 9 days.
                var refreshAfterOrTodayWithLag = (userTask.RefreshAfter ?? DateHelpers.Today).AddDays(difference);
                userTask.RefreshAfter = refreshAfterOrTodayWithLag > DateHelpers.Today ? refreshAfterOrTodayWithLag : null;
                // NOTE: Not updating the LastSeen date if RefreshAfter is null, so the user may see this task again tomorrow.
            }

            userTask.Order = viewModel.Order;
            userTask.Section = viewModel.Section;
            userTask.Enabled = viewModel.Enabled;
            userTask.LagRefreshXDays = viewModel.LagRefreshXDays;
            userTask.PadRefreshXDays = viewModel.PadRefreshXDays;
            userTask.DeloadAfterXWeeks = viewModel.DeloadAfterXWeeks;
            userTask.Notes = user.IsDemoUser ? null : viewModel.Notes;
            userTask.Source = user.IsDemoUser ? null : viewModel.Source;
            userTask.DeloadDurationWeeks = viewModel.DeloadDurationWeeks;
            userTask.PersistUntilComplete = viewModel.PersistUntilComplete;
            userTask.Name = user.IsDemoUser ? userTask.Name : viewModel.Name;
            userTask.Type = user.IsDemoUser ? userTask.Type : viewModel.Type;
            // Set these after the type has been updated. So that the demo user can't get these set.
            userTask.ReferenceMin = userTask.Type == UserTaskType.Log ? viewModel.ReferenceMin : null;
            userTask.ReferenceMax = userTask.Type == UserTaskType.Log ? viewModel.ReferenceMax : null;

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
