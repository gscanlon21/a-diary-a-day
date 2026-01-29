using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Anxiety;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class AnxietyViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Anxiety";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var userMood = await context.UserAnxieties.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserAnxieties.Where(ud => ud.UserId == user.Id).ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Anxiety", new AnxietyViewModel(userMoods)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new Data.Entities.Users.UserAnxiety()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
