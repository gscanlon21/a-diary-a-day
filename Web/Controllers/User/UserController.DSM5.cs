using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route("dryeyes")]
    public async Task<IActionResult> ManageDryEyes(string email, string token, UserDryEyes userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysDryEyes = await _context.UserDryEyes.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysDryEyes == null)
            {
                userMood.UserId = user.Id;
                _context.Add(userMood);
            }
            else
            {
                todaysDryEyes.DropsLast4Hours = userMood.DropsLast4Hours;
                todaysDryEyes.GelsLast12Hours = userMood.GelsLast12Hours;
                todaysDryEyes.DropDuration = userMood.DropDuration;
                todaysDryEyes.BurningFrequency = userMood.BurningFrequency;
                todaysDryEyes.BurningSeverity = userMood.BurningSeverity;
                todaysDryEyes.DropsUsedToday = userMood.DropsUsedToday;
                todaysDryEyes.DrynessFrequency = userMood.DrynessFrequency;
                todaysDryEyes.DrynessSeverity = userMood.DrynessSeverity;
                todaysDryEyes.EyeDrops = userMood.EyeDrops;
                todaysDryEyes.FatigueFrequency = userMood.FatigueFrequency;
                todaysDryEyes.FatigueSeverity = userMood.FatigueSeverity;
                todaysDryEyes.LastExeriencedSymptoms = userMood.LastExeriencedSymptoms;
                todaysDryEyes.MakeupToday = userMood.MakeupToday;
                todaysDryEyes.MoisturizerToday = userMood.MoisturizerToday;
                todaysDryEyes.SorenessFrequency = userMood.SorenessFrequency;
                todaysDryEyes.SorenessSeverity = userMood.SorenessSeverity;
                todaysDryEyes.TouchedEyesToday = userMood.TouchedEyesToday;
                todaysDryEyes.VisualBlinking = userMood.VisualBlinking;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("depression", Order = 1)]
    public async Task<IActionResult> ManageDepression(string email, string token, UserDepression userDepression)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysDepression = await _context.UserDepressions.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysDepression == null)
            {
                userDepression.User = user;
                _context.Add(userDepression);
            }
            else
            {
                todaysDepression.Depressed = userDepression.Depressed;
                todaysDepression.Failure = userDepression.Failure;
                todaysDepression.Helpless = userDepression.Helpless;
                todaysDepression.Hopeless = userDepression.Hopeless;
                todaysDepression.NoFuture = userDepression.NoFuture;
                todaysDepression.Sad = userDepression.Sad;
                todaysDepression.Unhappy = userDepression.Unhappy;
                todaysDepression.Worthless = userDepression.Worthless;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("panic-severity", Order = 1)]
    public async Task<IActionResult> ManagePanicSeverity(string email, string token, UserPanicSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserPanicSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Avoided = userMood.Avoided;
                todaysMood.Cope = userMood.Cope;
                todaysMood.DistractedMyself = userMood.DistractedMyself;
                todaysMood.Heart = userMood.Heart;
                todaysMood.LeftEarly = userMood.LeftEarly;
                todaysMood.LosingControl = userMood.LosingControl;
                todaysMood.Nervous = userMood.Nervous;
                todaysMood.Preparing = userMood.Preparing;
                todaysMood.SuddenTerror = userMood.SuddenTerror;
                todaysMood.Tense = userMood.Tense;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ptsd-severity", Order = 1)]
    public async Task<IActionResult> ManagePtsdSeverity(string email, string token, UserPostTraumaticStressSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserPostTraumaticStressSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Flashbacks = userMood.Flashbacks;
                todaysMood.Upset = userMood.Upset;
                todaysMood.StressfulEvent = userMood.StressfulEvent;
                todaysMood.Avoid = userMood.Avoid;
                todaysMood.Alert = userMood.Alert;
                todaysMood.Startled = userMood.Startled;
                todaysMood.Irritable = userMood.Irritable;
                todaysMood.NegativeEmotions = userMood.NegativeEmotions;
                todaysMood.NoInterest = userMood.NoInterest;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("Generalized-severity", Order = 1)]
    public async Task<IActionResult> ManageGeneralizedSeverity(string email, string token, UserGeneralizedAnxietySeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserGeneralizedAnxietySeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Avoided = userMood.Avoided;
                todaysMood.Cope = userMood.Cope;
                todaysMood.Fright = userMood.Fright;
                todaysMood.Heart = userMood.Heart;
                todaysMood.LeftEarly = userMood.LeftEarly;
                todaysMood.Accidents = userMood.Accidents;
                todaysMood.Nervous = userMood.Nervous;
                todaysMood.LeftEarly = userMood.LeftEarly;
                todaysMood.Time = userMood.Time;
                todaysMood.Reassurance = userMood.Reassurance;
                todaysMood.Tense = userMood.Tense;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("Dissociative-severity", Order = 1)]
    public async Task<IActionResult> ManageDissociativeSeverity(string email, string token, UserDissociativeSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserDissociativeSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Nothing = userMood.Nothing;
                todaysMood.Unreal = userMood.Unreal;
                todaysMood.NoMemory = userMood.NoMemory;
                todaysMood.TalkOutLoud = userMood.TalkOutLoud;
                todaysMood.Unclear = userMood.Unclear;
                todaysMood.IgnorePain = userMood.IgnorePain;
                todaysMood.DifferentPeople = userMood.DifferentPeople;
                todaysMood.EasyWhenHard = userMood.EasyWhenHard;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManageDepressionSeverity-severity", Order = 1)]
    public async Task<IActionResult> ManageDepressionSeverity(string email, string token, UserDepressionSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserDepressionSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.NoInterest = userMood.NoInterest;
                todaysMood.Hopeless = userMood.Hopeless;
                todaysMood.Sleeping = userMood.Sleeping;
                todaysMood.NoEnergy = userMood.NoEnergy;
                todaysMood.Eating = userMood.Eating;
                todaysMood.FeelingBad = userMood.FeelingBad;
                todaysMood.NoConcentration = userMood.NoConcentration;
                todaysMood.Slowly = userMood.Slowly;
                todaysMood.BetterOffDead = userMood.BetterOffDead;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManageAgoraphobiaSeverity-severity", Order = 1)]
    public async Task<IActionResult> ManageAgoraphobiaSeverity(string email, string token, UserAgoraphobiaSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserAgoraphobiaSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Avoided = userMood.Avoided;
                todaysMood.Cope = userMood.Cope;
                todaysMood.Fright = userMood.Fright;
                todaysMood.Heart = userMood.Heart;
                todaysMood.LeftEarly = userMood.LeftEarly;
                todaysMood.Panic = userMood.Panic;
                todaysMood.Nervous = userMood.Nervous;
                todaysMood.Preparing = userMood.Preparing;
                todaysMood.Distracted = userMood.Distracted;
                todaysMood.Tense = userMood.Tense;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("ManageStressSeverity-severity", Order = 1)]
    public async Task<IActionResult> ManageStressSeverity(string email, string token, UserAcuteStressSeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserAcuteStressSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Flashbacks = userMood.Flashbacks;
                todaysMood.Upset = userMood.Upset;
                todaysMood.Distant = userMood.Distant;
                todaysMood.Avoid = userMood.Avoid;
                todaysMood.Alert = userMood.Alert;
                todaysMood.Startled = userMood.Startled;
                todaysMood.Irritable = userMood.Irritable;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost]
    [Route("social-severity", Order = 1)]
    public async Task<IActionResult> ManageSocialAnxietySeverity(string email, string token, UserSocialAnxietySeverity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await _context.UserSocialAnxietySeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysMood.Avoided = userMood.Avoided;
                todaysMood.Cope = userMood.Cope;
                todaysMood.DistractedMyself = userMood.DistractedMyself;
                todaysMood.Heart = userMood.Heart;
                todaysMood.LeftEarly = userMood.LeftEarly;
                todaysMood.Humiliated = userMood.Humiliated;
                todaysMood.Nervous = userMood.Nervous;
                todaysMood.Preparing = userMood.Preparing;
                todaysMood.Fright = userMood.Fright;
                todaysMood.Tense = userMood.Tense;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
