﻿using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.People;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class PeopleViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "People";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await context.UserPeoples.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserPeoples.Include(ud => ud.UserCustoms).Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = await context.UserCustoms
            .Where(c => c.Type == CustomType.People)
            .Where(c => c.UserId == null || c.UserId == user.Id)
            .ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("People", new PeopleViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new Data.Entities.User.UserPeople()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
