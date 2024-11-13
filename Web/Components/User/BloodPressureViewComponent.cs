using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.BloodPressure;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class BloodPressureViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "BloodPressure";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserBloodPressures.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == DateHelpers.Today);
        var userMoods = await context.UserBloodPressures.Where(ud => ud.UserId == user.Id).ToListAsync();

        return View("BloodPressure", new BloodPressureViewModel(user, userMoods)
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            UserMood = userMood ?? new Data.Entities.User.UserBloodPressure()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
