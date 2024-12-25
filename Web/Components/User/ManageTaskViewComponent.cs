using Core.Models.Newsletter;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.ManageTask;

namespace Web.Components.User;

public class ManageTaskViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageTask";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public ManageTaskViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Data.Entities.Task.UserTask task, Section section = Section.Anytime)
    {
        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        if (task == null)
        {
            // Create a new user task.
            return View("ManageTask", new ManageTaskViewModel(user, new Data.Entities.Task.UserTask()
            {
                UserId = user.Id
            }, token));
        }

        var completedForSection = await _context.UserTaskLogs.AsNoTracking()
            .Where(ut => ut.Date == user.TodayOffset)
            .Where(ut => ut.UserTaskId == task.Id)
            .Where(ut => ut.Section == section)
            .AnyAsync(ut => ut.Complete > 0);

        var lastValue = await _context.UserTaskLogs.AsNoTracking()
            .Where(ut => ut.UserTaskId == task.Id)
            .Where(ut => ut.Section == section)
            .OrderByDescending(ut => ut.Date)
            .LastOrDefaultAsync();

        // Edit an existing user task.
        return View("ManageTask", new ManageTaskViewModel(user, task, token)
        {
            ManageSection = section,
            Value = lastValue?.Complete ?? default,
            CompletedForSection = completedForSection,
        });
    }
}
