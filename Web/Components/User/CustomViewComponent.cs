using Core.Models.Footnote;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

public class CustomViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Custom";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Custom footnotes must be enabled in the user edit form to show in the newsletter.
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return Content("");
        }

        var userFootnotes = await context.UserCustoms
            .Where(f => f.UserId == user.Id)
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Custom", new CustomViewModel()
        {
            User = user,
            Customs = userFootnotes,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
