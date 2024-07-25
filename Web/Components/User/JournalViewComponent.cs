using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Journal;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class JournalViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Journal";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userFootnotes = await context.UserJournals
            .Where(f => f.UserId == user.Id)
            .OrderBy(f => f.Value)
            .ToListAsync();

        return View("Journal", new JournalViewModel()
        {
            User = user,
            Journals = userFootnotes,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
