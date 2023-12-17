using Core.Models.Newsletter;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("m", Order = 1)]
    [Route("mood", Order = 2)]
    public async Task<IActionResult> ManageMood(string email, string token, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageMoodViewModel.TheParameters(email, token);

        var userMood = await context.UserMoods
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.UserId == user.Id);
        if (userMood == null)
        {
            userMood = new UserMood()
            {
                Date = Today,
                UserId = user.Id,
                Value = 0
            };

            context.Add(userMood);
            await context.SaveChangesAsync();
        }

        var userWeights = await context.UserMoods
                .Where(uw => uw.UserId == user.Id)
                .ToListAsync();

        return View(new UserManageMoodViewModel(userWeights, userMood.Value)
        {
            User = user,
            Parameters = parameters,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost]
    [Route("m", Order = 1)]
    [Route("mood", Order = 2)]
    public async Task<IActionResult> ManageMood(string email, string token, [Range(0, 999)] int weight)
    {
        if (ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var userMood = await context.UserMoods.FirstAsync(p => p.UserId == user.Id);
            userMood.Value = weight;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
