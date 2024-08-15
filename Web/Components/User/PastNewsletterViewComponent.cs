using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.PastNewsletter;

namespace Web.Components.User;

public class PastNewsletterViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "PastNewsletter";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var pastNewsletters = await userRepo.GetPastDiaries(user);
        if (!pastNewsletters.Any())
        {
            return Content("");
        }

        return View("PastNewsletter", new PastNewsletterViewModel()
        {
            User = user,
            PastNewsletters = pastNewsletters,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
