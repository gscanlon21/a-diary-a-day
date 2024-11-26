using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.SerumMaleHealth;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class SerumMaleHealthViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "SerumMaleHealth";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var i = 0;
        var userMood = await context.UserSerumMaleHealths.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserSerumMaleHealths.Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = userMoods.FirstOrDefault()?.Items.Keys.Select(a => new UserCustom()
        {
            Id = ++i,
            Count = i,
            Type = CustomType.None,
            Name = a,
        }).ToList();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var subComponents = (BloodWork)user.UserComponentSettings.First(s => s.Component == Component.BloodWork).TypedSkills!;
        return View("SerumMaleHealth", new SerumMaleHealthViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            SubComponents = subComponents,
            UserMood = new UserSerumMaleHealth()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
