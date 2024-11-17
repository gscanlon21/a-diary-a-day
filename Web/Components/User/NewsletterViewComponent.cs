using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Newsletter;

namespace Web.Components.User;

public class NewsletterViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Newsletter";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // User has not confirmed their account, they cannot see a workout yet.
        if (!user.LastActive.HasValue)
        {
            return Content("");
        }

        return View("Newsletter", new NewsletterViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
