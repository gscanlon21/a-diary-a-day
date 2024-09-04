using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route(nameof(Core.Models.User.Components.CompleteMetabolicPanel))]
    public async Task<IActionResult> ManageCompleteMetabolicPanel(string email, string token, UserCompleteMetabolicPanel userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserCompleteMetabolicPanels.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
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

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Core.Models.User.Components.CbcWAutoDiff))]
    public async Task<IActionResult> ManageCbcWAutoDiff(string email, string token, UserCbcWAutoDiff userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserCbcWAutoDiffs.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.WBC = userMood.WBC;
                todaysCompleteMetabolicPanel.RBCCount = userMood.RBCCount;
                todaysCompleteMetabolicPanel.Hemoglobin = userMood.Hemoglobin;
                todaysCompleteMetabolicPanel.Hematocrit = userMood.Hematocrit;
                todaysCompleteMetabolicPanel.MCV = userMood.MCV;
                todaysCompleteMetabolicPanel.MCH = userMood.MCH;
                todaysCompleteMetabolicPanel.MCHC = userMood.MCHC;
                todaysCompleteMetabolicPanel.RDW_CV = userMood.RDW_CV;
                todaysCompleteMetabolicPanel.PlatletCount = userMood.PlatletCount;
                todaysCompleteMetabolicPanel.MPV = userMood.MPV;
                todaysCompleteMetabolicPanel.MonocytePercent = userMood.MonocytePercent;
                todaysCompleteMetabolicPanel.EosinophilPercent = userMood.EosinophilPercent;
                todaysCompleteMetabolicPanel.BasophilPercent = userMood.BasophilPercent;
                todaysCompleteMetabolicPanel.ImmatureGranulocytesPercent = userMood.ImmatureGranulocytesPercent;
                todaysCompleteMetabolicPanel.EosinophilAbsolute = userMood.EosinophilAbsolute;
                todaysCompleteMetabolicPanel.NeutrophilAbsolute = userMood.NeutrophilAbsolute;
                todaysCompleteMetabolicPanel.MonocyteAbsolute = userMood.MonocyteAbsolute;
                todaysCompleteMetabolicPanel.LymphocyteAbsolute = userMood.LymphocyteAbsolute;
                todaysCompleteMetabolicPanel.BasophilAbsolute = userMood.BasophilAbsolute;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Core.Models.User.Components.BloodWork))]
    public async Task<IActionResult> ManageBloodWork(string email, string token, UserBloodWork userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserBloodWorks.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.VitaminA = userMood.VitaminA;
                todaysCompleteMetabolicPanel.Homocysteine = userMood.Homocysteine;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageMood), new { email, token, WasUpdated = false });
    }
}
