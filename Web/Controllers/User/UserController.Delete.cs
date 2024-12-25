using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Index;
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
            // Will also delete from related tables, cascade delete is enabled.
            // Schedule the api job to clean it up since that handles image deletions.
            // Double the decrement value in case we end up increasing DeleteAfterXMonths.
            user.LastActive = DateHelpers.Today.AddMonths(-2 * UserConsts.DeleteAfterXMonths);
        }

        try
        {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexController.Index), IndexController.Name, new { WasUnsubscribed = true });
        }
        catch
        {
            return RedirectToAction(nameof(IndexController.Index), IndexController.Name, new { WasUnsubscribed = false });
        }
    }

    [HttpPost, Route("ResendConfirmation")]
    public async Task<IActionResult> ResendConfirmation(string email, string token)
    {
        // TODO: Resend confirmation email.
        var user = await _userRepo.GetUser(email, token);
        return RedirectToAction(nameof(Edit), new { email, token });
    }
}
