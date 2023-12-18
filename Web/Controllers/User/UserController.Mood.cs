using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            .FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);

        var userWeights = await context.UserMoods
                .Where(uw => uw.UserId == user.Id)
                .ToListAsync();

        return View(new UserManageMoodViewModel(userWeights, (int?)userMood?.Mood)
        {
            User = user,
            Parameters = parameters,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost]
    [Route("m", Order = 1)]
    [Route("mood", Order = 2)]
    public async Task<IActionResult> ManageMood(string email, string token, UserMood userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var previousUserMood = await context.UserMoods.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);
            if (previousUserMood == null)
            {
                context.Add(new UserMood()
                {
                    Date = Today,
                    UserId = user.Id,
                    Mood = userMood.Mood
                });
            }
            else
            {
                previousUserMood.Mood = userMood.Mood;
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("s", Order = 1)]
    [Route("sleep", Order = 2)]
    public async Task<IActionResult> ManageSleep(string email, string token, UserSleep userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var previousUserMood = await context.UserSleeps.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);
            if (previousUserMood == null)
            {
                context.Add(new UserSleep()
                {
                    Date = Today,
                    UserId = user.Id,
                    SleepDuration = userMood.SleepDuration,
                    SleepTime = userMood.SleepTime
                });
            }
            else
            {
                previousUserMood.SleepDuration = userMood.SleepDuration;
                previousUserMood.SleepTime = userMood.SleepTime;
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
