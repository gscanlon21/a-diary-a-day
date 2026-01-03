using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Task;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpGet, Route("{component:component}")]
    public async Task<IActionResult> ManageComponent(string email, string token, Component component, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, includeSettings: true, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageComponentViewModel.TheParameters(email, token);
        return View(new UserManageComponentViewModel(component)
        {
            User = user,
            Parameters = parameters,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost, Route("{component:component}/show-log")]
    public async Task<IActionResult> ShowLog(string email, string token, Component component, UserComponentSetting setting)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return NotFound();
        }

        // Set the last completed date on the UserTask.
        var userTask = await _context.UserComponentSettings.FirstAsync(ut => ut.UserId == user.Id && ut.Component == component);
        userTask.Days = setting.Days;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ManageComponent), new { email, token, component, WasUpdated = true });
    }

    [HttpPost, Route("custom/add")]
    public async Task<IActionResult> AddCustom(string email, string token, [FromForm] string name, [FromForm] CustomType type, [FromForm] int order)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        _context.Add(new UserCustom()
        {
            User = user,
            Name = name,
            Order = order,
            Type = type,
            Icon = null,
        });

        await _context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your custom tags have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("custom/remove")]
    public async Task<IActionResult> RemoveCustom(string email, string token, [FromForm] int customId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await _context.UserCustoms
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == customId)
            .ExecuteDeleteAsync();

        await _context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your custom tags have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
