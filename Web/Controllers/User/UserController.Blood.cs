using Core.Code.Helpers;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route("completemetabolicpanel")]
    public async Task<IActionResult> ManageCompleteMetabolicPanel(string email, string token, UserCompleteMetabolicPanel userCompleteMetabolicPanel)
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
                userCompleteMetabolicPanel.User = user;
                context.Add(userCompleteMetabolicPanel);
            }
            else
            {
                todaysCompleteMetabolicPanel.Albumin = userCompleteMetabolicPanel.Albumin;
                todaysCompleteMetabolicPanel.Calcium = userCompleteMetabolicPanel.Calcium;
                todaysCompleteMetabolicPanel.BilirubinTotal = userCompleteMetabolicPanel.BilirubinTotal;
                todaysCompleteMetabolicPanel.BUN = userCompleteMetabolicPanel.BUN;
                todaysCompleteMetabolicPanel.AlkalinePhosphatase = userCompleteMetabolicPanel.AlkalinePhosphatase;
                todaysCompleteMetabolicPanel.AST = userCompleteMetabolicPanel.AST;
                todaysCompleteMetabolicPanel.Chloride = userCompleteMetabolicPanel.Chloride;
                todaysCompleteMetabolicPanel.Glucose = userCompleteMetabolicPanel.Glucose;
                todaysCompleteMetabolicPanel.AnionGap = userCompleteMetabolicPanel.AnionGap;
                todaysCompleteMetabolicPanel.CO2 = userCompleteMetabolicPanel.CO2;
                todaysCompleteMetabolicPanel.EGFRbyCKDEPI = userCompleteMetabolicPanel.EGFRbyCKDEPI;
                todaysCompleteMetabolicPanel.Creatinine = userCompleteMetabolicPanel.Creatinine;
                todaysCompleteMetabolicPanel.ALT = userCompleteMetabolicPanel.ALT;
                todaysCompleteMetabolicPanel.Potassium = userCompleteMetabolicPanel.Potassium;
                todaysCompleteMetabolicPanel.ProteinTotal = userCompleteMetabolicPanel.ProteinTotal;
                todaysCompleteMetabolicPanel.Sodium = userCompleteMetabolicPanel.Sodium;
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
