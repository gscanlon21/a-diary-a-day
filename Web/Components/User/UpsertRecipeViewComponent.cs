using Data;
using Data.Entities.Task;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Code;
using Web.Views.Shared.Components.UpsertRecipe;

namespace Web.Components.User;

public class UpsertRecipeViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "UpsertRecipe";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, UserTask? recipe = null)
    {
        // User must own the recipe to be able to edit it.
        if (recipe != null && recipe.UserId != user.Id)
        {
            return Content("");
        }

        recipe ??= new UserTask()
        {
            User = user
        };

        return View("UpsertRecipe", new UpsertRecipeViewModel()
        {
            User = user,
            Recipe = recipe.AsType<UpsertRecipeModel, UserTask>()!,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
