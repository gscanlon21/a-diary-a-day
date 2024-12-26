using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.SupplementStudies;

namespace Web.Components.UserTask;

public class SupplementStudiesViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public SupplementStudiesViewComponent(UserRepo userRepo, CoreContext context)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "SupplementStudies";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Data.Entities.Task.UserTask task)
    {
        if (task == null || !user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        var userLogs = await _context.StudySupplements
            .Where(s => s.UserTaskId == task.Id)
            .ToListAsync();

        return View("SupplementStudies", new SupplementStudiesViewModel()
        {
            User = user,
            Token = token,
            Supplement = task,
            Studies = userLogs,
        });
    }
}