using Microsoft.AspNetCore.Mvc;
using Web.Code.TempData;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route("feast")]
    public async Task<IActionResult> EditFeast(string email, string token, [FromForm] string feastEmail, [FromForm] string? feastToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        user.FeastEmail = feastEmail;
        user.FeastToken = feastToken;

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your preferences have been saved.";
        return RedirectToAction(nameof(Edit), new { email, token, WasUpdated = true });
    }
}

