using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.User;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Tasks;

namespace Web.Components.User;

/// <summary>
/// Lists all of the user's active tasks.
/// </summary>
public class TasksViewComponent(IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Tasks";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Filtering options.
        var taskType = Enum.TryParse(Request.Query["type"], ignoreCase: true, out UserTaskType typeTmp) ? typeTmp : (UserTaskType?)null;

        // Need a user context so the manage link is clickable and the user can un-ignore a task.
        var userNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token);

        var tasks = await new QueryBuilder()
            .WithUser(user, ignored: false)
            .WithTasks(options => options.All = true)
            .WithTaskType(taskType)
            .Build()
            .Query(serviceScopeFactory);

        return View("Tasks", new TasksViewModel()
        {
            UserNewsletter = userNewsletter,
            Tasks = tasks.Select(r => r.AsType<NewsletterTaskDto>()!).ToList(),
        });
    }
}
