using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class AcuteStressSeverityViewComponent(IServiceScopeFactory serviceScopeFactory, CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "AcuteStressSeverity";

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);


    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userDepression = await context.UserAcuteStressSeverities.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == Today);
        var userDepressions = await context.UserAcuteStressSeverities.Where(ud => ud.UserId == user.Id).ToListAsync();

        var viewModel = new AcuteStressSeverityViewModel(userDepressions, userDepression?.Score)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            UserMood = userDepression ?? new Data.Entities.User.UserAcuteStressSeverity()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("AcuteStressSeverity", viewModel);
    }
}
