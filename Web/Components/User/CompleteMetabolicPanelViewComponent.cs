using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.CompleteMetabolicPanel;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class CompleteMetabolicPanelViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "CompleteMetabolicPanel";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserCompleteMetabolicPanels.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserCompleteMetabolicPanels.Where(ud => ud.UserId == user.Id).ToListAsync();
        var viewModel = new CompleteMetabolicPanelViewModel(userMoods)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserCompleteMetabolicPanel()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("CompleteMetabolicPanel", viewModel);
    }
}
