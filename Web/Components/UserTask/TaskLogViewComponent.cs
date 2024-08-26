using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.TaskLog;

namespace Web.Components.UserTask;

public class TaskLogViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public TaskLogViewComponent(UserRepo userRepo, CoreContext context)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "TaskLog";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Data.Entities.Task.UserTask task)
    {
        if (task == null) { return Content(""); }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        var userLogs = await _context.UserTaskLogs
            .Where(uw => uw.UserTaskId == task.Id)
            .ToListAsync();

        return View("TaskLog", new TaskLogViewModel(user, userLogs)
        {
            Token = token,
            Name = task.Uid.ToString(),
        });
    }
}