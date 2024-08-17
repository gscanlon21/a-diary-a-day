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
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageMoodViewModel.TheParameters(email, token);

        var userMood = await _context.UserMoods
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);

        var userWeights = await _context.UserMoods
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var previousUserMood = await _context.UserMoods.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (previousUserMood == null)
            {
                _context.Add(new UserMood()
                {
                    Date = DateHelpers.Today,
                    UserId = user.Id,
                    Mood = userMood.Mood
                });
            }
            else
            {
                previousUserMood.Mood = userMood.Mood;
            }

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();

            var previousUserMood = await _context.UserSleeps.Include(us => us.UserCustoms).FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (previousUserMood != null)
            {
                previousUserMood.UserCustoms.Clear();
                previousUserMood.UserCustoms.AddRange(userCustoms);
                previousUserMood.SleepDuration = userMood.SleepDuration;
                previousUserMood.SleepTime = userMood.SleepTime;
            }
            else
            {
                _context.Add(new UserSleep()
                {
                    Date = DateHelpers.Today,
                    UserId = user.Id,
                    SleepDuration = userMood.SleepDuration,
                    SleepTime = userMood.SleepTime,
                    UserCustoms = userCustoms
                });
            }

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            _context.UserActivities.RemoveRange(_context.UserActivities.Where(uf => uf.UserId == user.Id && uf.Date == DateHelpers.Today));
            _context.UserActivities.Add(new UserActivity()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            _context.UserEmotions.RemoveRange(_context.UserEmotions.Where(uf => uf.UserId == user.Id && uf.Date == DateHelpers.Today));
            _context.UserEmotions.Add(new UserEmotion()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            _context.UserMedicines.RemoveRange(_context.UserMedicines.Where(uf => uf.UserId == user.Id && uf.Date == DateHelpers.Today));
            _context.UserMedicines.Add(new UserMedicine()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            _context.UserPeoples.RemoveRange(_context.UserPeoples.Where(uf => uf.UserId == user.Id && uf.Date == DateHelpers.Today));
            _context.UserPeoples.Add(new UserPeople()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await _context.SaveChangesAsync();
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
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            var customIds = customs.Where(f => f.Selected).Select(ic => ic.Id).ToList();
            var userCustoms = await _context.UserCustoms.Where(c => customIds.Contains(c.Id)).ToListAsync();
            _context.UserSymptoms.RemoveRange(_context.UserSymptoms.Where(uf => uf.UserId == user.Id && uf.Date == DateHelpers.Today));
            _context.UserSymptoms.Add(new UserSymptom()
            {
                User = user,
                UserCustoms = userCustoms
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
