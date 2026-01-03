using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.BloodPressure;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class BloodPressureViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public BloodPressureViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "BloodPressure";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var i = 0;
        var setting = await _context.UserComponentSettings.FirstAsync(s => s.UserId == user.Id && s.Component == Component.BloodPressure);
        var userMood = await _context.UserBloodPressures.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == DateHelpers.Today);
        var userMoods = await _context.UserBloodPressures.Where(ud => ud.UserId == user.Id).ToListAsync();
        var userCustoms = userMoods.FirstOrDefault()?.Items.Keys.Select(a => new UserCustom()
        {
            Id = ++i,
            Count = i,
            Type = CustomType.None,
            Name = a,
        }).ToList();

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("BloodPressure", new BloodPressureViewModel(userMoods, userCustoms, setting.Days)
        {
            User = user,
            Token = token,
            Setting = setting,
            PreviousMood = userMood,
            UserMood = userMood ?? new UserBloodPressure()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
