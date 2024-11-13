using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Sleep;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class SleepViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Sleep";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await context.UserSleeps.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == DateHelpers.Today);
        var userMoods = (await context.UserSleeps
            .Include(ud => ud.UserCustoms)
            .Where(ud => ud.UserId == user.Id)
            .ToListAsync());
        var userCustoms = await context.UserCustoms
            .Where(c => c.Type == CustomType.Sleep)
            .Where(c => c.UserId == null || c.UserId == user.Id)
            .ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Sleep", new SleepViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            UserMood = userMood ?? new Data.Entities.User.UserSleep()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
