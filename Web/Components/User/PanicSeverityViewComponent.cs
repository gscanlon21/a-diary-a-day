using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.PanicSeverity;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class PanicSeverityViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "PanicSeverity";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserPanicSeverities.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserPanicSeverities.Where(ud => ud.UserId == user.Id).ToListAsync();

        return View("PanicSeverity", new PanicSeverityViewModel(user, userMoods)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserPanicSeverity()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
