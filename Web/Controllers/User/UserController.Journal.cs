using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route("journal/add")]
    public async Task<IActionResult> AddJournal(string email, string token, [FromForm] string note, [FromForm] string? source)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Add a new journal entry.
        _context.Add(new UserJournal(user, note));
        await _context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your journal entries have been updated!";
        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
    }

    [HttpPost, Route("journal/remove")]
    public async Task<IActionResult> RemoveJournal(string email, string token, [FromForm] int footnoteId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Delete the user's journal entry.
        await _context.UserJournals
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == footnoteId)
            .ExecuteDeleteAsync();

        TempData[TempData_User.SuccessMessage] = "Your journal entries have been updated!";
        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
    }
}
