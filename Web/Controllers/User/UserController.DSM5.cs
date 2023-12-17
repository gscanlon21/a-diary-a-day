using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost]
    [Route("depression", Order = 1)]
    public async Task<IActionResult> ManageDepression(string email, string token, UserDepression userDepression)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysDepression = await context.UserDepressions.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);
            if (todaysDepression == null)
            {
                userDepression.User = user;
                context.Add(userDepression);
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

            await context.SaveChangesAsync();
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
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysMood = await context.UserPanicSeverities.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == Today);
            if (todaysMood == null)
            {
                userMood.User = user;
                userMood.Score = userMood.Items.Sum(i => i.GetValueOrDefault()) / userMood.Items.Count(i => i.HasValue);
                context.Add(userMood);
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
                todaysMood.Score = todaysMood.Items.Sum(i => i.GetValueOrDefault()) / todaysMood.Items.Count(i => i.HasValue);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
