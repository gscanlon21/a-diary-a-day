using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Task;
using Data.Models;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.ManageRecipe;

namespace Web.Components.User;

public class ManageTaskViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageTask";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ManageTaskViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, UserTask task)
    {
        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        if (task == null)
        {
            return View("ManageTask", new ManageTaskViewModel()
            {
                User = user,
                Token = token,
                UserTask = new UserTask()
                {
                    UserId = user.Id
                }
            });
        }

        var userTask = await _context.UserTasks.AsNoTracking().FirstOrDefaultAsync(r => r.UserId == user.Id && r.Id == task.Id);
        if (userTask == null) { return Content(""); }

        var taskDto = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreIgnored: true)
            .WithTasks(x =>
            {
                x.AddTasks([task]);
            })
            .Build()
            .Query(_serviceScopeFactory))
            // May return more than one recipe if the recipe has ingredient recipes.
            .FirstOrDefault(r => r.Task.Id == task.Id);

        return View("ManageTask", new ManageTaskViewModel()
        {
            User = user,
            Token = token,
            UserTask = userTask,
            Name = userTask.Name,
            Notes = userTask.Notes,
            Section = userTask.Section,
            LagRefreshXDays = userTask.LagRefreshXDays,
            PadRefreshXDays = userTask.PadRefreshXDays,
            Task = taskDto?.AsType<NewsletterTaskDto, QueryResults>()!,
        });
    }
}
