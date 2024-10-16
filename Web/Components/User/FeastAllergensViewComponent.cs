﻿using Core.Models.Footnote;
using Core.Models.User;
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

        var userCustoms = EnumExtensions.GetValuesExcluding32(Allergy.None).Select(a => new UserCustom()
        {
            Id = (int)a,
            Count = (int)a,
            Type = CustomType.None,
            Name = a.GetSingleDisplayName(),
        }).ToList();

        return View("FeastAllergens", new FeastAllergensViewModel(userMoods, userCustoms)
        {
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            User = user,
            PreviousMood = userMood,
            UserMood = new UserFeastAllergens()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
