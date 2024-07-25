using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class LinkFeastsViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "LinkFeasts";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userFootnotes = await context.UserJournals
            .Where(f => f.UserId == user.Id)
            .OrderBy(f => f.Value)
            .ToListAsync();

        return View("LinkFeasts", new JournalViewModel()
        {
            User = user,
            Journals = userFootnotes,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
