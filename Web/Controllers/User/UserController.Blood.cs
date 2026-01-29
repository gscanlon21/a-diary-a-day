using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost, Route(nameof(Component.BodyTemp))]
    public async Task<IActionResult> ManageBodyTemp(string email, string token, UserBodyTemp userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysBodyTemp = await _context.UserBodyTemps.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysBodyTemp == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysBodyTemp.BodyTemp = userMood.BodyTemp;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BodyTemp, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BodyTemp, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.BloodPressure))]
    public async Task<IActionResult> ManageBloodPressure(string email, string token, UserBloodPressure userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysBloodPressure = await _context.UserBloodPressures.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysBloodPressure == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysBloodPressure.DiastolicPressure = userMood.DiastolicPressure;
                todaysBloodPressure.SystolicPressure = userMood.SystolicPressure;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BloodPressure, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BloodPressure, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.CompleteMetabolicPanel))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.CompleteMetabolicPanel, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.CompleteMetabolicPanel, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.CbcWAutoDiff))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.CbcWAutoDiff, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.CbcWAutoDiff, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.BloodWork))]
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
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BloodWork, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.BloodWork, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumBlood))]
    public async Task<IActionResult> ManageSerumBlood(string email, string token, UserSerumBlood userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumBlood.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.MPV = userMood.MPV;
                todaysCompleteMetabolicPanel.PlateletCount = userMood.PlateletCount;
                todaysCompleteMetabolicPanel.Hematocrit = userMood.Hematocrit;
                todaysCompleteMetabolicPanel.Hemoglobin = userMood.Hemoglobin;
                todaysCompleteMetabolicPanel.RBCCount = userMood.RBCCount;
                todaysCompleteMetabolicPanel.MCH = userMood.MCH;
                todaysCompleteMetabolicPanel.MCHC = userMood.MCHC;
                todaysCompleteMetabolicPanel.MCV = userMood.MCV;
                todaysCompleteMetabolicPanel.RDW = userMood.RDW;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumBlood, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumBlood, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumElectrolytes))]
    public async Task<IActionResult> ManageSerumElectrolytes(string email, string token, UserSerumElectrolytes userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumElectrolytes.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.Potassium = userMood.Potassium;
                todaysCompleteMetabolicPanel.Sodium = userMood.Sodium;
                todaysCompleteMetabolicPanel.Magnesium = userMood.Magnesium;
                todaysCompleteMetabolicPanel.Calcium = userMood.Calcium;
                todaysCompleteMetabolicPanel.CarbonDioxide = userMood.CarbonDioxide;
                todaysCompleteMetabolicPanel.Chloride = userMood.Chloride;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumElectrolytes, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumElectrolytes, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumFemaleHealth))]
    public async Task<IActionResult> ManageSerumFemaleHealth(string email, string token, UserSerumFemaleHealth userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumFemaleHealths.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.SHBG = userMood.SHBG;
                todaysCompleteMetabolicPanel.FreePSA = userMood.FreePSA;
                todaysCompleteMetabolicPanel.DHEASulfate = userMood.DHEASulfate;
                todaysCompleteMetabolicPanel.E2 = userMood.E2;
                todaysCompleteMetabolicPanel.FSH = userMood.FSH;
                todaysCompleteMetabolicPanel.LH = userMood.LH;
                todaysCompleteMetabolicPanel.Prolactin = userMood.Prolactin;
                todaysCompleteMetabolicPanel.TotalPSA = userMood.TotalPSA;
                todaysCompleteMetabolicPanel.FreePSAPercent = userMood.FreePSAPercent;
                todaysCompleteMetabolicPanel.FreeTestosterone = userMood.FreeTestosterone;
                todaysCompleteMetabolicPanel.TotalTestosterone = userMood.TotalTestosterone;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumFemaleHealth, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumFemaleHealth, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumHeart))]
    public async Task<IActionResult> ManageSerumHeart(string email, string token, UserSerumHeart userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumHearts.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.HDLLarge = userMood.HDLLarge;
                todaysCompleteMetabolicPanel.LDLMedium = userMood.LDLMedium;
                todaysCompleteMetabolicPanel.LDLParticleNumber = userMood.LDLParticleNumber;
                todaysCompleteMetabolicPanel.LDLPattern = userMood.LDLPattern;
                todaysCompleteMetabolicPanel.LDLPeakSize = userMood.LDLPeakSize;
                todaysCompleteMetabolicPanel.LDLSmall = userMood.LDLSmall;
                todaysCompleteMetabolicPanel.LDLCholesterol = userMood.LDLCholesterol;
                todaysCompleteMetabolicPanel.NonHDLCholesterol = userMood.NonHDLCholesterol;
                todaysCompleteMetabolicPanel.Triglycerides = userMood.Triglycerides;
                todaysCompleteMetabolicPanel.HDLCholesterol = userMood.HDLCholesterol;
                todaysCompleteMetabolicPanel.HsCRP = userMood.HsCRP;
                todaysCompleteMetabolicPanel.LipoproteinA = userMood.LipoproteinA;
                todaysCompleteMetabolicPanel.TotalCholesterol = userMood.TotalCholesterol;
                todaysCompleteMetabolicPanel.TotalCholesterolHDL = userMood.TotalCholesterolHDL;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumHeart, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumHeart, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumHeavyMetals))]
    public async Task<IActionResult> ManageSerumHeavyMetals(string email, string token, UserSerumHeavyMetals userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumHeavyMetals.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.Mercury = userMood.Mercury;
                todaysCompleteMetabolicPanel.Lead = userMood.Lead;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumHeavyMetals, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumHeavyMetals, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumAutoimmunity))]
    public async Task<IActionResult> ManageSerumAutoimmunity(string email, string token, UserSerumAutoimmunity userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumAutoimmunity.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.AntinuclearAntibodies = userMood.AntinuclearAntibodies;
                todaysCompleteMetabolicPanel.RheumatoidFactor = userMood.RheumatoidFactor;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumAutoimmunity, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumAutoimmunity, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumImmuneRegulation))]
    public async Task<IActionResult> ManageSerumImmuneRegulation(string email, string token, UserSerumImmuneRegulation userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumImmuneRegulations.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.EosinophilisPercent = userMood.EosinophilisPercent;
                todaysCompleteMetabolicPanel.Eosinophilis = userMood.Eosinophilis;
                todaysCompleteMetabolicPanel.LymphocytesPercent = userMood.LymphocytesPercent;
                todaysCompleteMetabolicPanel.Lymphocytes = userMood.Lymphocytes;
                todaysCompleteMetabolicPanel.MonocytesPercent = userMood.MonocytesPercent;
                todaysCompleteMetabolicPanel.Monocytes = userMood.Monocytes;
                todaysCompleteMetabolicPanel.BasophilisPercent = userMood.BasophilisPercent;
                todaysCompleteMetabolicPanel.Basophilis = userMood.Basophilis;
                todaysCompleteMetabolicPanel.NeutrophilisPercent = userMood.NeutrophilisPercent;
                todaysCompleteMetabolicPanel.Neutrophilis = userMood.Neutrophilis;
                todaysCompleteMetabolicPanel.HsCRP = userMood.HsCRP;
                todaysCompleteMetabolicPanel.WBCCount = userMood.WBCCount;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumImmuneRegulation, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumImmuneRegulation, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumKidney))]
    public async Task<IActionResult> ManageSerumKidney(string email, string token, UserSerumKidney userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumKidneys.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.AlbuminUrine = userMood.AlbuminUrine;
                todaysCompleteMetabolicPanel.BUN = userMood.BUN;
                todaysCompleteMetabolicPanel.Calcium = userMood.Calcium;
                todaysCompleteMetabolicPanel.Chloride = userMood.Chloride;
                todaysCompleteMetabolicPanel.Creatinine = userMood.Creatinine;
                todaysCompleteMetabolicPanel.EGFR = userMood.EGFR;
                todaysCompleteMetabolicPanel.Potassium = userMood.Potassium;
                todaysCompleteMetabolicPanel.Sodium = userMood.Sodium;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumKidney, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumKidney, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumLiver))]
    public async Task<IActionResult> ManageSerumLiver(string email, string token, UserSerumLiver userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumLivers.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.ALT = userMood.ALT;
                todaysCompleteMetabolicPanel.Albumin = userMood.Albumin;
                todaysCompleteMetabolicPanel.AlbuminGlobulin = userMood.AlbuminGlobulin;
                todaysCompleteMetabolicPanel.ALP = userMood.ALP;
                todaysCompleteMetabolicPanel.AST = userMood.AST;
                todaysCompleteMetabolicPanel.GGT = userMood.GGT;
                todaysCompleteMetabolicPanel.Globulin = userMood.Globulin;
                todaysCompleteMetabolicPanel.Bilirubin = userMood.Bilirubin;
                todaysCompleteMetabolicPanel.Protein = userMood.Protein;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumLiver, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumLiver, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumMaleHealth))]
    public async Task<IActionResult> ManageSerumMaleHealth(string email, string token, UserSerumMaleHealth userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumMaleHealths.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.SHBG = userMood.SHBG;
                todaysCompleteMetabolicPanel.FreePSA = userMood.FreePSA;
                todaysCompleteMetabolicPanel.DHEASulfate = userMood.DHEASulfate;
                todaysCompleteMetabolicPanel.E2 = userMood.E2;
                todaysCompleteMetabolicPanel.FSH = userMood.FSH;
                todaysCompleteMetabolicPanel.LH = userMood.LH;
                todaysCompleteMetabolicPanel.Prolactin = userMood.Prolactin;
                todaysCompleteMetabolicPanel.TotalPSA = userMood.TotalPSA;
                todaysCompleteMetabolicPanel.FreePSAPercent = userMood.FreePSAPercent;
                todaysCompleteMetabolicPanel.FreeTestosterone = userMood.FreeTestosterone;
                todaysCompleteMetabolicPanel.TotalTestosterone = userMood.TotalTestosterone;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumMaleHealth, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumMaleHealth, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumMetabolic))]
    public async Task<IActionResult> ManageSerumMetabolic(string email, string token, UserSerumMetabolic userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumMetabolics.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.Glucose = userMood.Glucose;
                todaysCompleteMetabolicPanel.UricAcid = userMood.UricAcid;
                todaysCompleteMetabolicPanel.HbA1c = userMood.HbA1c;
                todaysCompleteMetabolicPanel.Insulin = userMood.Insulin;
                todaysCompleteMetabolicPanel.Leptin = userMood.Leptin;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumMetabolic, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumMetabolic, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumNutrients))]
    public async Task<IActionResult> ManageSerumNutrients(string email, string token, UserSerumNutrients userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumNutrients.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.MMA = userMood.MMA;
                todaysCompleteMetabolicPanel.Homocysteine = userMood.Homocysteine;
                todaysCompleteMetabolicPanel.Ferritin = userMood.Ferritin;
                todaysCompleteMetabolicPanel.Calcium = userMood.Calcium;
                todaysCompleteMetabolicPanel.Iron = userMood.Iron;
                todaysCompleteMetabolicPanel.IronSat = userMood.IronSat;
                todaysCompleteMetabolicPanel.IronBindingCapacity = userMood.IronBindingCapacity;
                todaysCompleteMetabolicPanel.Magnesium = userMood.Magnesium;
                todaysCompleteMetabolicPanel.Zinc = userMood.Zinc;
                todaysCompleteMetabolicPanel.VitaminD = userMood.VitaminD;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumNutrients, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumNutrients, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumPancreas))]
    public async Task<IActionResult> ManageSerumPancreas(string email, string token, UserSerumPancreas userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumPancreas.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.Amylase = userMood.Amylase;
                todaysCompleteMetabolicPanel.Lipase = userMood.Lipase;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumPancreas, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumPancreas, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumStress))]
    public async Task<IActionResult> ManageSerumStress(string email, string token, UserSerumStress userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumStress.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.DHEASulfate = userMood.DHEASulfate;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumStress, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumStress, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.SerumThyroid))]
    public async Task<IActionResult> ManageSerumThyroid(string email, string token, UserSerumThyroid userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserSerumThyroids.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.TgAb = userMood.TgAb;
                todaysCompleteMetabolicPanel.TPO = userMood.TPO;
                todaysCompleteMetabolicPanel.TSH = userMood.TSH;
                todaysCompleteMetabolicPanel.T4 = userMood.T4;
                todaysCompleteMetabolicPanel.T3 = userMood.T3;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumThyroid, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.SerumThyroid, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.Urine))]
    public async Task<IActionResult> ManageUrine(string email, string token, UserUrine userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysCompleteMetabolicPanel = await _context.UserUrines.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysCompleteMetabolicPanel == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysCompleteMetabolicPanel.Albumin = userMood.Albumin;
                todaysCompleteMetabolicPanel.Bilirubin = userMood.Bilirubin;
                todaysCompleteMetabolicPanel.Glucose = userMood.Glucose;
                todaysCompleteMetabolicPanel.Ketones = userMood.Ketones;
                todaysCompleteMetabolicPanel.Leukocyte = userMood.Leukocyte;
                todaysCompleteMetabolicPanel.Nitrate = userMood.Nitrate;
                todaysCompleteMetabolicPanel.OccultBlood = userMood.OccultBlood;
                todaysCompleteMetabolicPanel.Protein = userMood.Protein;
                todaysCompleteMetabolicPanel.SpecificGravity = userMood.SpecificGravity;
                todaysCompleteMetabolicPanel.PH = userMood.PH;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Urine, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.Urine, WasUpdated = false });
    }
}
