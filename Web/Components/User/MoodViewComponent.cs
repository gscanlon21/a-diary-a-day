using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Mood;

namespace Web.Components.User;

/// <summary>
/// Component for tracking mood changes over time.
/// </summary>
public class MoodViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public MoodViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Mood";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await _context.UserMoods.FirstOrDefaultAsync(ud => ud.UserId == user.Id && ud.Date == DateHelpers.Today);
        var userMoods = await _context.UserMoods.Where(ud => ud.UserId == user.Id).ToListAsync();

        var setting = await _context.UserComponentSettings
            .Where(s => s.UserId == user.Id).AsNoTracking()
            .Where(s => s.Component == Component.Mood)
            .FirstOrDefaultAsync() ?? new UserComponentSetting()
            {
                Days = UserConsts.ChartDaysDefault,
                Component = Component.Mood,
                UserId = user.Id,
            };

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("Mood", new MoodViewModel(user, userMoods)
        {
            User = user,
            Token = token,
            Setting = setting,
            UserMood = userMood ?? new UserMood()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
