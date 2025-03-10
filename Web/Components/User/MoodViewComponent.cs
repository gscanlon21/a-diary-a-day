﻿using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Mood;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class MoodViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Mood";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await context.UserMoods.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == DateHelpers.Today);
        var userMoods = await context.UserMoods.Where(ud => ud.UserId == user.Id).ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Mood", new MoodViewModel(user, userMoods)
        {
            User = user,
            Token = token,
            UserMood = userMood ?? new Data.Entities.User.UserMood()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
