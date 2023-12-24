using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class AngerViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Anger";

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserAngers.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserAngers.Where(ud => ud.UserId == user.Id).ToListAsync();
        var viewModel = new AngerViewModel(userMoods)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserAnger()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("Anger", viewModel);
    }
}
