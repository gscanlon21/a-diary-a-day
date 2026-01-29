using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, Data.Entities.Task.UserTask task, Section section)
    {
        if (task?.Type != UserTaskType.Supplement || !user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        var studySupplements = await _context.StudySupplements
            .Where(s => s.UserTaskId == task.Id)
            .ToListAsync();

        var studies = await _context.Studies.ToListAsync();
        return View("SupplementStudies", new SupplementStudiesViewModel()
        {
            User = user,
            Token = token,
            Section = section,
            Supplement = task,
            StudySupplements = studySupplements,
            Studies = studies.Select(s => new SelectListItem()
            {
                Text = s.Source,
                Value = s.Id.ToString()
            }).ToList(),
        });
    }
}