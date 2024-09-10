using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route(nameof(Component.Mood))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Mood, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Mood, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Sleep))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Sleep, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Sleep, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Activity))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Activity, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Activity, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Emotion))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Emotion, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Emotion, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Medicine))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Medicine, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Medicine, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.People))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.People, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.People, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Symptom))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Symptom, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Symptom, WasUpdated = false });
    }
}
