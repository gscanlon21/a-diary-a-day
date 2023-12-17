using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class ManiaViewComponent(IServiceScopeFactory serviceScopeFactory, CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Mania";

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userDepression = await context.UserManias.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == Today);
        var userDepressions = await context.UserManias.Where(ud => ud.UserId == user.Id).ToListAsync();

        var viewModel = new ManiaViewModel(userDepressions, userDepression?.Score)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            UserMood = userDepression ?? new Data.Entities.User.UserMania()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("Mania", viewModel);
    }
}
