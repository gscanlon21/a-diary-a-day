using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.BackupRestore;

namespace Web.Components.User;

/// <summary>
/// Allows the user to backup and restore their data.
/// </summary>
public class BackupRestoreViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "BackupRestore";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        return View("BackupRestore", new BackupRestoreViewModel(user, token));
    }
}
