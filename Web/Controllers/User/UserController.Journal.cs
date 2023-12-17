using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost]
    [Route("journal/add")]
    public async Task<IActionResult> AddJournal(string email, string token, [FromForm] string note, [FromForm] string? source)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        context.Add(new UserJournal()
        {
            User = user,
            Value = note
        });

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your footnotes have been updated!";
        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
    }

    [HttpPost]
    [Route("journal/remove")]
    public async Task<IActionResult> RemoveJournal(string email, string token, [FromForm] int footnoteId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserJournals
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == footnoteId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your footnotes have been updated!";
        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
    }
}
