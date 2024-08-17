using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers.Index;
using Web.ViewModels.User;
using Web.Views.Shared.Components.Edit;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// User delete confirmation page.
    /// </summary>
    [HttpGet]
    [Route("d", Order = 1)]
    [Route("delete", Order = 2)]
    public async Task<IActionResult> Delete(string email, string token)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View(new UserEditViewModel(user, token));
    }

    [HttpPost]
    [Route("d", Order = 1)]
    [Route("delete", Order = 2)]
    public async Task<IActionResult> DeleteConfirmed(string email, string token)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user != null)
        {
            _context.UserMoods.RemoveRange(await _context.UserMoods.Where(n => n.UserId == user.Id).ToListAsync());
            _context.Users.Remove(user); // Will also remove from ExerciseUserProgressions and EquipmentUsers
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(IndexController.Index), IndexController.Name, new { WasUnsubscribed = true });
    }
}
