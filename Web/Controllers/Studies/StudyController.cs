using Data;
using Data.Entities.Genetics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers.User;
using Web.Views.Study;

namespace Web.Controllers.Studies;

[Route($"{Name}")]
public class StudyController : ViewController
{
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public StudyController(CoreContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Study";

    [HttpGet, Route("add")]
    public async Task<IActionResult> Add([FromQuery] int supplementId)
    {
        return View(new AddViewModel()
        {
            SupplementId = supplementId
        });
    }

    [HttpPost, Route("add")]
    public async Task<IActionResult> AddPost(AddViewModel viewModel)
    {
        var task = await _context.UserTasks.FirstOrDefaultAsync(t => t.Id == viewModel.SupplementId);
        var existingStudy = await _context.StudySupplements.FirstOrDefaultAsync(s => s.UserTaskId == viewModel.SupplementId);
        if (existingStudy == null)
        {
            var newStudy = new StudySupplement()
            {
                UserTaskId = viewModel.SupplementId,
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
            TaskId = viewModel.SupplementId,
        });
    }
}
