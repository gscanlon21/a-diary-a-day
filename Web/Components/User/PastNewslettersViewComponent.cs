using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.PastNewsletters;

namespace Web.Components.User;

public class PastNewslettersViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "PastNewsletters";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        var pastNewsletters = await userRepo.GetPastDiaries(user);
        if (!pastNewsletters.Any())
        {
            return Content("");
        }

        return View("PastNewsletters", new PastNewslettersViewModel()
        {
            User = user,
            Token = token,
            PastNewsletters = pastNewsletters,
        });
    }
}
