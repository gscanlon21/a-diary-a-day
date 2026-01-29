using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Emotion;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class EmotionViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Emotion";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user)
    {
        var userMood = await context.UserEmotions.OrderByDescending(d => d.Date).FirstOrDefaultAsync(ud => ud.UserId == user.Id);
        var userMoods = (await context.UserEmotions
            .Include(ud => ud.UserCustoms)
            .Where(ud => ud.UserId == user.Id)
            .ToListAsync());
        var userCustoms = await context.UserCustoms
            .Where(c => c.Type == CustomType.Emotion)
            .Where(c => c.UserId == null || c.UserId == user.Id)
            .ToListAsync();

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Emotion", new EmotionViewModel(userMoods, userCustoms)
        {
            User = user,
            Token = token,
            PreviousMood = userMood,
            UserMood = new Data.Entities.Users.UserEmotion()
            {
                UserId = user.Id,
                User = user
            },
        });
    }
}
