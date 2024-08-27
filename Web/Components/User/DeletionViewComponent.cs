using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Deletion;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary whether the user is confirmed or not.
/// </summary>
public class DeletionViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Deletion";

    public DeletionViewComponent() { }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var deletionDate = DateHelpers.Today.AddMonths(-UserConsts.DeleteAfterXMonths);
        if (!user.LastActive.HasValue || user.LastActive >= deletionDate)
        {
            return Content("");
        }

        return View("Deletion", new DeletionViewModel());
    }
}
