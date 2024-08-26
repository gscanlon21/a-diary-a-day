using Core.Consts;
using Core.Models;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Edit;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class EditViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Edit";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User? user = null)
    {
        user ??= await userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, includeSettings: true, allowDemoUser: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        if (viewModel.ComponentsBinder != null)
        {
            foreach (var component in viewModel.ComponentsBinder
                .OrderBy(mg => mg.GetSingleDisplayName(DisplayType.GroupName))
                .ThenBy(mg => mg.GetSingleDisplayName()))
            {
                var userComponentSetting = viewModel.User.UserComponentSettings.SingleOrDefault(umm => umm.Component == component);
                viewModel.UserComponentSettings.Add(userComponentSetting != null ? new UserEditViewModel.UserEditComponentSkillViewModel(userComponentSetting) : new UserEditViewModel.UserEditComponentSkillViewModel()
                {
                    UserId = viewModel.User.Id,
                    Component = component,
                    Days = 180
                });
            }
        }

        return viewModel;
    }
}
