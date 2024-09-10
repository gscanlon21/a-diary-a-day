using Microsoft.AspNetCore.Mvc;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpGet, Route("{component:component}")]
    public async Task<IActionResult> ManageComponent(string email, string token, Component component, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, includeSettings: true, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageComponentViewModel.TheParameters(email, token);
        return View(new UserManageComponentViewModel(component)
        {
            User = user,
            Parameters = parameters,
            WasUpdated = wasUpdated,
        });
    }
}
