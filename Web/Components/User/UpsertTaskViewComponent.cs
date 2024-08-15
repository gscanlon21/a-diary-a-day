using Data.Entities.Task;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Code;
using Web.Views.Shared.Components.UpsertTask;

namespace Web.Components.User;

public class UpsertTaskViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "UpsertTask";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, UserTask? task = null)
    {
        // User must own the recipe to be able to edit it.
        if (task != null && task.UserId != user.Id)
        {
            return Content("");
        }

        task ??= new UserTask()
        {
            User = user
        };

        return View("UpsertTask", new UpsertTaskViewModel()
        {
            User = user,
            Task = task.AsType<UpsertTaskModel, UserTask>()!,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
