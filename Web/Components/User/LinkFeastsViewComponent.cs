using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.LinkFeasts;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class LinkFeastsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "LinkFeasts";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        return View("LinkFeasts", new LinkFeastsViewModel()
        {
            Token = token,
            Email = user.Email,
            FeastEmail = user.FeastEmail,
            FeastToken = user.FeastToken,
        });
    }
}
