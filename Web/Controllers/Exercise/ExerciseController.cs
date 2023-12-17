using Core.Consts;
using Microsoft.AspNetCore.Mvc;
using Web.Code.Attributes;
using Web.ViewModels.Exercise;

namespace Web.Controllers.Exercise;

[Route("exercise")]
public partial class ExerciseController(IServiceScopeFactory serviceScopeFactory) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Exercise";

    [Route("all"), ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(ExercisesViewModel? viewModel = null)
    {
        viewModel ??= new ExercisesViewModel();

        return View(viewModel);
    }
}
