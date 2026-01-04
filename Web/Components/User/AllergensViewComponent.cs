using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Allergens;

namespace Web.Components.User;

/// <summary>
/// Component for tracking the user's A Feast a Day allergens over time.
/// </summary>
public class AllergensViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public AllergensViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Allergens";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await _context.UserAllergens.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await _context.UserAllergens
            .Where(ud => ud.UserId == user.Id)
            .ToListAsync();

        var setting = await _context.UserComponentSettings
            .Where(s => s.UserId == user.Id).AsNoTracking()
            .Where(s => s.Component == Component.Allergens)
            .FirstOrDefaultAsync() ?? new UserComponentSetting()
            {
                Days = UserConsts.ChartDaysDefault,
                Component = Component.Allergens,
                UserId = user.Id,
            };

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("Allergens", new AllergensViewModel(userMoods, setting.Days)
        {
            User = user,
            Token = token,
            Setting = setting,
            PreviousMood = userMood,
            UserMood = new UserAllergens()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
