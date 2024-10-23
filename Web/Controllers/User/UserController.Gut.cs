using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;


public partial class UserController
{
    [HttpPost, Route(nameof(Component.GutPillars))]
    public async Task<IActionResult> ManageGutPillars(string email, string token, UserGutPillars userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutPillars.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.GutDysbiosis = userMood.GutDysbiosis;
                todaysGut.Digestion = userMood.Digestion;
                todaysGut.Inflammation = userMood.Inflammation;
                todaysGut.ImmuneReadinessScore = userMood.ImmuneReadinessScore;
                todaysGut.NervousSystem = userMood.NervousSystem;
                todaysGut.IntestinalPermeability = userMood.IntestinalPermeability;
                todaysGut.DiversityScore = userMood.DiversityScore;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPillars, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPillars, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutFungi))]
    public async Task<IActionResult> ManageGutFungi(string email, string token, UserGutFungi userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutFungi.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.TotalFungi = userMood.TotalFungi;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutFungi, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutFungi, WasUpdated = false });
    }
}
