using Core.Models.Footnote;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.FeastAllergens;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class FeastAllergensViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "FeastAllergens";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserFeastAllergens.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserFeastAllergens
            .Where(ud => ud.UserId == user.Id)
            .ToListAsync();

        var userCustoms = userMoods.SelectMany(em => em.Allergens.Select(a => new UserCustom()
        {
            Id = (int)a.Key,
            Count = (int)a.Value,
            Type = CustomType.None,
            Name = a.Key.GetSingleDisplayName(),
        })).ToList();

        var viewModel = new FeastAllergensViewModel(userMoods, userCustoms)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            PreviousMood = userMood,
            UserMood = new UserFeastAllergens()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("FeastAllergens", viewModel);
    }
}
