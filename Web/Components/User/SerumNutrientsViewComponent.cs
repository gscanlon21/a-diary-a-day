using Core.Models.User;
using Data;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.SerumNutrients;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class SerumNutrientsViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "SerumNutrients";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var i = 0;
        var userMood = await context.UserSerumNutrients.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserSerumNutrients.Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = userMoods.FirstOrDefault()?.Items.Keys.Select(a => new UserCustom()
        {
            Id = ++i,
            Count = i,
            Type = CustomType.None,
            Name = a,
        }).ToList();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("SerumNutrients", new SerumNutrientsViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new UserSerumNutrients()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
