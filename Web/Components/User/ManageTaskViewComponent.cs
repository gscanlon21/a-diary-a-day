using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Task;
using Data.Models;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.User;

namespace Web.Components.User;

public class ManageTaskViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "ManageTask";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, UserTask task, UserManageTaskViewModel.Params parameters)
    {
        var userTask = await context.UserTasks.AsNoTracking().FirstOrDefaultAsync(r => r.UserId == user.Id && r.Id == parameters.RecipeId);
        if (userTask == null)
        {
            return Content("");
        }

        if (userTask == null) { return Content(""); }
        var taskDto = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreIgnored: true)
            .WithTasks(x =>
            {
                x.AddTasks([task]);
            })
            .Build()
            .Query(serviceScopeFactory))
            // May return more than one recipe if the recipe has ingredient recipes.
            .FirstOrDefault(r => r.Task.Id == task.Id);

        //if (recipeDto == null) { return Content(""); }
        return View("ManageTask", new ManageTaskViewModel()
        {
            User = user,
            UserTask = userTask,
            Notes = userTask.Notes,
            Parameters = parameters,
            LagRefreshXDays = userTask.LagRefreshXDays,
            PadRefreshXDays = userTask.PadRefreshXDays,
            Task = taskDto?.AsType<NewsletterTaskDto, QueryResults>()!,
        });
    }
}
