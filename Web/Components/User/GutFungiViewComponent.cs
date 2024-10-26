﻿using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.GutFungi;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class GutFungiViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "GutFungi";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var i = 0;
        var token = await userRepo.AddUserToken(user, durationDays: 1);
        var userMood = await context.UserGutFungi.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await context.UserGutFungi.Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = userMoods.FirstOrDefault()?.Items.Keys.Select(a => new UserCustom()
        {
            Id = ++i,
            Count = i,
            Type = CustomType.None,
            Name = a,
        }).ToList();

        var viewModel = new GutFungiViewModel(userMoods, userCustoms)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            PreviousMood = userMood,
            UserMood = new UserGutFungi()
            {
                UserId = user.Id,
                User = user
            },
        };

        return View("GutFungi", viewModel);
    }
}
