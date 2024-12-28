using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route(nameof(Component.SalivaStress))]
    public async Task<IActionResult> ManageSalivaStress(string email, string token, UserSalivaStress userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserSalivaStress.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.DHEA = userMood.DHEA;
                todaysGut.MorningCortisol = userMood.MorningCortisol;
                todaysGut.EveningCortisol = userMood.EveningCortisol;
                todaysGut.DaytimeCortisol = userMood.DaytimeCortisol;
                todaysGut.NightCortisol = userMood.NightCortisol;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SalivaStress, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SalivaStress, WasUpdated = false });
    }
}
