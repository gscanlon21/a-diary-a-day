using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.PastNewsletters;

namespace Web.Components.User;

public class PastNewslettersViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public PastNewslettersViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "PastNewsletters";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        // User has not confirmed their account, newsletters won't render.
        if (!user.LastActive.HasValue)
        {
            return Content("");
        }

        var pastNewsletters = await _userRepo.GetPastDiaries(user);
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
