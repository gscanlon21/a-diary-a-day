﻿using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Anger;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class AngerViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Anger";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserAngers.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserAngers.Where(ud => ud.UserId == user.Id).ToListAsync();

        return View("Anger", new AngerViewModel(userMoods)
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserAnger()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
