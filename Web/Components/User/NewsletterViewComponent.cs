using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Newsletter;

namespace Web.Components.User;

public class NewsletterViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public NewsletterViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Newsletter";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // User has not confirmed their account, let the backfill finish first.
        if (!user.LastActive.HasValue)
        {
            return Content("");
        }

        // Use the persistent token so the user can bookmark this.
        token = await _userRepo.GetPersistentToken(user) ?? token;
        return View("Newsletter", new NewsletterViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
