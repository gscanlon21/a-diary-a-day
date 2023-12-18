using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class SleepViewComponent(IServiceScopeFactory serviceScopeFactory, CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Sleep";

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);


    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserSleeps.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == Today);
        var userMoods = await context.UserSleeps.Where(ud => ud.UserId == user.Id).ToListAsync();
        var viewModel = new SleepViewModel(userMoods)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            UserMood = userMood ?? new Data.Entities.User.UserSleep()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("Sleep", viewModel);
    }
}
