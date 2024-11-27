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
public class FeastAllergensViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public FeastAllergensViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "FeastAllergens";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var userMood = await _context.UserFeastAllergens.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = await _context.UserFeastAllergens
            .Where(ud => ud.UserId == user.Id)
            .ToListAsync();

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("FeastAllergens", new FeastAllergensViewModel(userMoods)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new UserFeastAllergens()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
