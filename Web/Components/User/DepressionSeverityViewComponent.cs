using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.DepressionSeverity;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class DepressionSeverityViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "DepressionSeverity";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserDepressionSeverities.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserDepressionSeverities.Where(ud => ud.UserId == user.Id).ToListAsync();

        return View("DepressionSeverity", new DepressionSeverityViewModel(userMoods)
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserDepressionSeverity()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
