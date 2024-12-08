using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Allergens;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
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

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("Allergens", new AllergensViewModel(userMoods)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new UserAllergens()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
