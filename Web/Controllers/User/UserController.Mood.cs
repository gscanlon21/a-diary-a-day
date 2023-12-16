using Core.Consts;
using Core.Models.Newsletter;
using Data.Dtos.Newsletter;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web.Code;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("m", Order = 1)]
    [Route("mood", Order = 2)]
    public async Task<IActionResult> ManageMood(string email, string token, int exerciseId, int variationId, Section section, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageMoodViewModel.TheParameters(section, email, token, exerciseId, variationId);
      
        var userExercise = await context.UserExercises
            .IgnoreQueryFilters()
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.ExerciseId == exerciseId);

        if (userExercise == null)
        {
            userExercise = new UserExercise()
            {
                UserId = user.Id,
                ExerciseId = exerciseId,
                Progression = user.IsNewToFitness ? UserConsts.MinUserProgression : UserConsts.MidUserProgression,
            };

            context.UserExercises.Add(userExercise);
            await context.SaveChangesAsync();
        }

        return View(new UserManageMoodViewModel()
        {
            User = user,
            Parameters = parameters,
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost]
    [Route("m", Order = 1)]
    [Route("mood", Order = 2)]
    public async Task<IActionResult> ManageMood(string email, string token, int exerciseId, int variationId, Section section, [Range(0, 999)] int weight)
    {
        if (ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }
        
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, exerciseId, variationId, section, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, exerciseId, variationId, section, WasUpdated = false });
    }
}
