using Data;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.DryEyes;

namespace Web.Components.User;

/// <summary>
/// Component for tracking dry eye changes over time.
/// </summary>
public class DryEyesViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public DryEyesViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "DryEyes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var userMood = await _context.UserDryEyes.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await _context.UserDryEyes.Where(ud => ud.UserId == user.Id).ToListAsync();

        var setting = await _context.UserComponentSettings
            .Where(s => s.UserId == user.Id).AsNoTracking()
            .Where(s => s.Component == Component.DryEyes)
            .FirstOrDefaultAsync() ?? new UserComponentSetting()
            {
                Days = UserConsts.ChartDaysDefault,
                Component = Component.DryEyes,
                UserId = user.Id,
            };

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("DryEyes", new DryEyesViewModel(userMoods)
        {
            User = user,
            Token = token,
            Setting = setting,
            PreviousMood = userMood,
            UserMood = new UserDryEyes()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
