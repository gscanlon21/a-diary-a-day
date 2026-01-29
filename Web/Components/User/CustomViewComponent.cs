using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Custom;

namespace Web.Components.User;

public class CustomViewComponent(CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Custom";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        var userFootnotes = await context.UserCustoms
            .Where(f => f.UserId == user.Id)
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Custom", new CustomViewModel()
        {
            User = user,
            Token = token,
            Customs = userFootnotes,
        });
    }
}
