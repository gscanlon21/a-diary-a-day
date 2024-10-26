using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Depression;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class DepressionViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Depression";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserDepressions.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserDepressions.Where(ud => ud.UserId == user.Id).ToListAsync();

        return View("Depression", new DepressionViewModel(userMoods)
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            UserDepression = new Data.Entities.User.UserDepression()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
