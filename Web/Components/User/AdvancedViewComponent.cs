using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Advanced;

namespace Web.Components.User;

/// <summary>
/// User's advanced preferences edit form.
/// </summary>
public class AdvancedViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Advanced";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        return View("Advanced", new AdvancedViewModel(user, token));
    }
}
