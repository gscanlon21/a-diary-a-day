using Core.Models.Newsletter;
using Data;
using Data.Entities.Genetics;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers.User;
using Web.Views.Shared.Components.SupplementStudies;
using Web.Views.Study;

namespace Web.Controllers.Studies;

[Route($"{Name}")]
public class StudyController : ViewController
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public StudyController(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Study";

    [HttpGet, Route("[action]")]
    public async Task<IActionResult> AddStudy(string email, string token, [FromQuery] int supplementId, [FromQuery] Section section)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View("Add", new AddViewModel()
        {
            User = user,
            Token = token,
            Section = section,
            SupplementId = supplementId,
        });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> AddStudyPost(string email, string token, AddViewModel viewModel)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var task = await _context.UserTasks.FirstOrDefaultAsync(t => t.Id == viewModel.SupplementId);
        var existingStudy = await _context.Studies.FirstOrDefaultAsync(s => s.Source == viewModel.Source);
        if (existingStudy == null)
        {
            var newStudy = new Study()
            {
                Name = viewModel.Name,
                Source = viewModel.Source,
            };

            _context.Studies.Add(newStudy);
        }
        else
        {
            existingStudy.Name = viewModel.Name;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(UserController.Name, nameof(UserController.ManageTask), new
        {
            viewModel.Section,
            TaskId = viewModel.SupplementId,
        });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> AddSupplementStudy(SupplementStudiesViewModel viewModel)
    {
        var task = await _context.UserTasks.FirstOrDefaultAsync(t => t.Id == viewModel.Supplement.Id);
        var existingStudySupplement = await _context.StudySupplements.FirstOrDefaultAsync(s => s.UserTaskId == viewModel.Supplement.Id);
        if (existingStudySupplement == null)
        {
            var newStudy = new StudySupplement()
            {
                UserTaskId = viewModel.Supplement.Id,
            };

            _context.StudySupplements.Add(newStudy);
        }
        else
        {
            //existingStudy.Temp = viewModel.Temp;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(UserController.Name, nameof(UserController.ManageTask), new
        {
            TaskId = viewModel.Supplement.Id,
        });
    }

    [HttpPost, Route("remove")]
    public async Task<IActionResult> RemoveStudy(string email, string token, [FromForm] int studyId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        /*
        await _context.UserFootnotes
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == footnoteId)
            .ExecuteDeleteAsync();

        await _context.SaveChangesAsync();
        */

        TempData[TempData_User.SuccessMessage] = "The studies have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
