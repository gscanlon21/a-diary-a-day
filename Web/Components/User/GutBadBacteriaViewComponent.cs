using Core.Models.User;
using Data;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.GutBadBacteria;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class GutBadBacteriaViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "GutBadBacteria";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var i = 0;
        var userMood = await context.UserGutBadBacterias.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserGutBadBacterias.Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = userMoods.FirstOrDefault()?.Items.Keys.Select(a => new UserCustom()
        {
            Id = ++i,
            Count = i,
            Type = CustomType.None,
            Name = a,
        }).ToList();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("GutBadBacteria", new GutBadBacteriaViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new UserGutBadBacteria()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
