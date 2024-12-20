﻿using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.DryEyes;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class DryEyesViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "DryEyes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await context.UserDryEyes.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserDryEyes.Where(ud => ud.UserId == user.Id).ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("DryEyes", new DryEyesViewModel(userMoods)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserDryEyes()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
