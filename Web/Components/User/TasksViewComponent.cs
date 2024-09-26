using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.User;
using Data;
using Data.Models;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Tasks;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class TasksViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Tasks";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        if (!user.Components.HasFlag(Component.Tasks))
        {
            return Content("");
        }

        // Filtering options.
        var taskType = Enum.TryParse(Request.Query["type"], ignoreCase: true, out UserTaskType typeTmp) ? typeTmp : UserTaskType.None;

        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userNewsletter = new UserNewsletterDto(user.AsType<UserDto, Data.Entities.User.User>()!, token);

        var userRecipes = await context.UserTasks
            .Where(r => r.UserId == user.Id)
            .ToListAsync();

        var tasks = await new QueryBuilder()
            // Include disabled tasks.
            .WithUser(user, ignored: false)
            .WithTasks(x =>
            {
                x.AddTasks(userRecipes);
            })
            .Build()
            .Query(serviceScopeFactory);

        // TODO: Move this into the query runner.
        if (taskType != UserTaskType.None)
        {
            tasks = tasks.Where(t => t.Task.Type == taskType).ToList();
        }

        return View("Tasks", new TasksViewModel()
        {
            UserNewsletter = userNewsletter,
            Tasks = tasks.Select(r => r.AsType<NewsletterTaskDto, QueryResults>()!).ToList(),
        });
    }
}
