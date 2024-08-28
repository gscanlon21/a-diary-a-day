using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.LinkFeasts;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class LinkFeastsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "LinkFeasts";

    private readonly UserRepo _userRepo;

    public LinkFeastsViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        return View("LinkFeasts", new LinkFeastsViewModel()
        {
            Email = user.Email,
            FeastEmail = user.FeastEmail,
            FeastToken = user.FeastToken,
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
