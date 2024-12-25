using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Web.Code.Attributes;
using Web.Views.Supplements;

namespace Web.Controllers.Supplements;

[Route($"{Name}")]
public class SupplementsController : ViewController
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public SupplementsController(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Supplements";

    [Route("")]
    [ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(SupplementsViewModel? viewModel = null)
    {
        viewModel ??= new SupplementsViewModel();

        var queryBuilder = new QueryBuilder(viewModel.Section);

        viewModel.Supplements = (await queryBuilder
            .WithTasks((options) =>
            {
                options.All = true;
            })
            .Build().Query(_serviceScopeFactory))
            .Select(r => r.AsType<NewsletterTaskDto>()!)
            .ToList();

        if (!string.IsNullOrWhiteSpace(viewModel.Name))
        {
            viewModel.Supplements = viewModel.Supplements.Where(vm =>
                vm.Task.Name.Contains(viewModel.Name, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return View(viewModel);
    }
}
