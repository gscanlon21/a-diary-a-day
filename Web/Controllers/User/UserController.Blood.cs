using Core.Code.Helpers;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route("completemetabolicpanel")]
    public async Task<IActionResult> ManageCompleteMetabolicPanel(string email, string token, UserCompleteMetabolicPanel userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await context.UserCompleteMetabolicPanels.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.ALT = userMood.ALT;
                todaysCompleteMetabolicPanel.AST = userMood.AST;
                todaysCompleteMetabolicPanel.BUN = userMood.BUN;
                todaysCompleteMetabolicPanel.CO2 = userMood.CO2;
                todaysCompleteMetabolicPanel.Sodium = userMood.Sodium;
                todaysCompleteMetabolicPanel.Albumin = userMood.Albumin;
                todaysCompleteMetabolicPanel.Calcium = userMood.Calcium;
                todaysCompleteMetabolicPanel.Glucose = userMood.Glucose;
                todaysCompleteMetabolicPanel.Chloride = userMood.Chloride;
                todaysCompleteMetabolicPanel.AnionGap = userMood.AnionGap;
                todaysCompleteMetabolicPanel.Potassium = userMood.Potassium;
                todaysCompleteMetabolicPanel.Creatinine = userMood.Creatinine;
                todaysCompleteMetabolicPanel.EGFRbyCKDEPI = userMood.EGFRbyCKDEPI;
                todaysCompleteMetabolicPanel.ProteinTotal = userMood.ProteinTotal;
                todaysCompleteMetabolicPanel.BilirubinTotal = userMood.BilirubinTotal;
                todaysCompleteMetabolicPanel.AlkalinePhosphatase = userMood.AlkalinePhosphatase;
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
