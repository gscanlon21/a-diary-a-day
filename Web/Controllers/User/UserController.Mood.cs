using Data.Entities.Footnote;
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
    public async Task<IActionResult> ManageSleep(string email, string token, UserSleep userMood, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();

            var previousUserMood = await context.UserSleeps.Include(us => us.UserCustoms).FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);
            if (previousUserMood  != null)
            {
                previousUserMood.UserCustoms.Clear();
                previousUserMood.UserCustoms.AddRange(userCustoms);
                previousUserMood.SleepDuration = userMood.SleepDuration;
                previousUserMood.SleepTime = userMood.SleepTime;
            }
            else
            {
                context.Add(new UserSleep()
                {
                    Date = Today,
                    UserId = user.Id,
                    SleepDuration = userMood.SleepDuration,
                    SleepTime = userMood.SleepTime,
                    UserCustoms = userCustoms
                });
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("activities", Order = 1)]
    public async Task<IActionResult> ManageActivity(string email, string token, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            context.UserActivities.RemoveRange(context.UserActivities.Where(uf => uf.UserId == user.Id && uf.Date == Today));
            context.UserActivities.Add(new UserActivity()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManageEmotions", Order = 1)]
    public async Task<IActionResult> ManageEmotion(string email, string token, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            context.UserEmotions.RemoveRange(context.UserEmotions.Where(uf => uf.UserId == user.Id && uf.Date == Today));
            context.UserEmotions.Add(new UserEmotion()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManageMedicines", Order = 1)]
    public async Task<IActionResult> ManageMedicine(string email, string token, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            context.UserMedicines.RemoveRange(context.UserMedicines.Where(uf => uf.UserId == user.Id && uf.Date == Today));
            context.UserMedicines.Add(new UserMedicine()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManagePeoples", Order = 1)]
    public async Task<IActionResult> ManagePeople(string email, string token, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            context.UserPeoples.RemoveRange(context.UserPeoples.Where(uf => uf.UserId == user.Id && uf.Date == Today));
            context.UserPeoples.Add(new UserPeople()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("symptoms", Order = 1)]
    public async Task<IActionResult> ManageSymptom(string email, string token, List<UserCustom> customs)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            context.UserSymptoms.RemoveRange(context.UserSymptoms.Where(uf => uf.UserId == user.Id && uf.Date == Today));
            context.UserSymptoms.Add(new UserSymptom()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
