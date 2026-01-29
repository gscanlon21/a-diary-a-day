using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Mania;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class ManiaViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Mania";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var userMood = await context.UserManias.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserManias.Where(ud => ud.UserId == user.Id).ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Mania", new ManiaViewModel(userMoods)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new Data.Entities.Users.UserMania()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
