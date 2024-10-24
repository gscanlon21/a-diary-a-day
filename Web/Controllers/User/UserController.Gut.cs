using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.User;


public partial class UserController
{
    [HttpPost, Route(nameof(Component.GutPillars))]
    public async Task<IActionResult> ManageGutPillars(string email, string token, UserGutPillars userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutPillars.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.GutDysbiosis = userMood.GutDysbiosis;
                todaysGut.Digestion = userMood.Digestion;
                todaysGut.Inflammation = userMood.Inflammation;
                todaysGut.ImmuneReadinessScore = userMood.ImmuneReadinessScore;
                todaysGut.NervousSystem = userMood.NervousSystem;
                todaysGut.IntestinalPermeability = userMood.IntestinalPermeability;
                todaysGut.DiversityScore = userMood.DiversityScore;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPillars, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPillars, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutFungi))]
    public async Task<IActionResult> ManageGutFungi(string email, string token, UserGutFungi userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutFungi.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.TotalFungi = userMood.TotalFungi;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutFungi, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutFungi, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutPathogens))]
    public async Task<IActionResult> ManageGutPathogens(string email, string token, UserGutPathogens userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutPathogens.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.Blastocystis = userMood.Blastocystis;
                todaysGut.Campylobacter = userMood.Campylobacter;
                todaysGut.ClostridioidesDifficile = userMood.ClostridioidesDifficile;
                todaysGut.Cryptosporidium = userMood.Cryptosporidium;
                todaysGut.DientamoebaFragilis = userMood.DientamoebaFragilis;
                todaysGut.EntamoebaHistolytica = userMood.EntamoebaHistolytica;
                todaysGut.EscherichiaColiO157_H7 = userMood.EscherichiaColiO157_H7;
                todaysGut.GiardiaIntestinalis = userMood.GiardiaIntestinalis;
                todaysGut.HelicobacterPylori = userMood.HelicobacterPylori;
                todaysGut.SalmonellaEnterica = userMood.SalmonellaEnterica;
                todaysGut.VibrioCholerae = userMood.VibrioCholerae;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPathogens, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutPathogens, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutProbiotics))]
    public async Task<IActionResult> ManageGutProbiotics(string email, string token, UserGutProbiotics userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutProbiotics.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.BacillusCoagulans = userMood.BacillusCoagulans;
                todaysGut.BifidobacteriumAnimalisSubspAnimalis = userMood.BifidobacteriumAnimalisSubspAnimalis;
                todaysGut.BifidobacteriumAnimalisSubspLactis = userMood.BifidobacteriumAnimalisSubspLactis;
                todaysGut.BifidobacteriumBifidum = userMood.BifidobacteriumBifidum;
                todaysGut.BifidobacteriumBreve = userMood.BifidobacteriumBreve;
                todaysGut.BifidobacteriumLongumSubspInfantis = userMood.BifidobacteriumLongumSubspInfantis;
                todaysGut.BifidobacteriumLongumSubspLongum = userMood.BifidobacteriumLongumSubspLongum;
                todaysGut.LactobacillusAcidophilus = userMood.LactobacillusAcidophilus;
                todaysGut.LactobacillusBrevis = userMood.LactobacillusBrevis;
                todaysGut.LactobacillusCasei = userMood.LactobacillusCasei;
                todaysGut.LactobacillusDelbrueckiiSubspBulgaricus = userMood.LactobacillusDelbrueckiiSubspBulgaricus;
                todaysGut.LactobacillusDelbrueckiiSubspDelbrueckii = userMood.LactobacillusDelbrueckiiSubspDelbrueckii;
                todaysGut.LactobacillusFermentum = userMood.LactobacillusFermentum;
                todaysGut.LactobacillusGasseri = userMood.LactobacillusGasseri;
                todaysGut.LactobacillusHelveticus = userMood.LactobacillusHelveticus;
                todaysGut.LactobacillusParacasei = userMood.LactobacillusParacasei;
                todaysGut.LactobacillusPlantarum = userMood.LactobacillusPlantarum;
                todaysGut.LactobacillusReuteri = userMood.LactobacillusReuteri;
                todaysGut.LactobacillusRhamnosus = userMood.LactobacillusRhamnosus;
                todaysGut.LactobacillusSalivarius = userMood.LactobacillusSalivarius;
                todaysGut.LactococcusLactis = userMood.LactococcusLactis;
                todaysGut.PropionibacteriumFreudenreichii = userMood.PropionibacteriumFreudenreichii;
                todaysGut.StreptococcusSalivarius = userMood.StreptococcusSalivarius;
                todaysGut.StreptococcusThermophilus = userMood.StreptococcusThermophilus;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutProbiotics, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutProbiotics, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutShortChainFattyAcids))]
    public async Task<IActionResult> ManageGutShortChainFattyAcids(string email, string token, UserGutShortChainFattyAcids userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutShortChainFattyAcids.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.Butyrate = userMood.Butyrate;
                todaysGut.Lactate = userMood.Lactate;
                todaysGut.Propionate = userMood.Propionate;
                todaysGut.Valerate = userMood.Valerate;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutShortChainFattyAcids, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutShortChainFattyAcids, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutMicronutrients))]
    public async Task<IActionResult> ManageGutMicronutrients(string email, string token, UserGutMicronutrients userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutMicronutrients.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.VitaminB3 = userMood.VitaminB3;
                todaysGut.VitaminB6 = userMood.VitaminB6;
                todaysGut.VitaminB9 = userMood.VitaminB9;
                todaysGut.VitaminB12 = userMood.VitaminB12;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutMicronutrients, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutMicronutrients, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutGoodBacteria))]
    public async Task<IActionResult> ManageGutGoodBacteria(string email, string token, UserGutGoodBacteria userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutGoodBacterias.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.AkkermansiaMuciniphila = userMood.AkkermansiaMuciniphila;
                todaysGut.Alistipes = userMood.Alistipes;
                todaysGut.Bifidobacterium = userMood.Bifidobacterium;
                todaysGut.Coprococcus = userMood.Coprococcus;
                todaysGut.Eubacterium = userMood.Eubacterium;
                todaysGut.EubacteriumRectale = userMood.EubacteriumRectale;
                todaysGut.FaecalibacteriumPrausnitzii = userMood.FaecalibacteriumPrausnitzii;
                todaysGut.LachnospiraceaeMinusBlautia = userMood.LachnospiraceaeMinusBlautia;
                todaysGut.Oscillospira = userMood.Oscillospira;
                todaysGut.Parabacteroides = userMood.Parabacteroides;
                todaysGut.Roseburia = userMood.Roseburia;
                todaysGut.RuminococcusMinusRBromii = userMood.RuminococcusMinusRBromii;
                todaysGut.Ruminococcaceae = userMood.Ruminococcaceae;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutGoodBacteria, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutGoodBacteria, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutBadBacteria))]
    public async Task<IActionResult> ManageGutBadBacteria(string email, string token, UserGutBadBacteria userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutBadBacterias.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.Blautia = userMood.Blautia;
                todaysGut.CitrobacterFreundii = userMood.CitrobacterFreundii;
                todaysGut.ClostridioidesDifficile = userMood.ClostridioidesDifficile;
                todaysGut.Eggerthella = userMood.Eggerthella;
                todaysGut.EggerthellaLenta = userMood.EggerthellaLenta;
                todaysGut.Enterobacteriaceae = userMood.Enterobacteriaceae;
                todaysGut.EnterobacteriaceaeAndPseudomonas = userMood.EnterobacteriaceaeAndPseudomonas;
                todaysGut.Enterococcus = userMood.Enterococcus;
                todaysGut.EnterococcusFaecalis = userMood.EnterococcusFaecalis;
                todaysGut.EnterococcusFaecium = userMood.EnterococcusFaecium;
                todaysGut.EnterococcusFaecalisAndFaecium = userMood.EnterococcusFaecalisAndFaecium;
                todaysGut.Escherichia = userMood.Escherichia;
                todaysGut.EscherichiaColi = userMood.EscherichiaColi;
                todaysGut.Klebsiella = userMood.Klebsiella;
                todaysGut.RuminococcusGnavus = userMood.RuminococcusGnavus;
                todaysGut.RuminococcusTorques = userMood.RuminococcusTorques;
                todaysGut.Staphylococcus = userMood.Staphylococcus;
                todaysGut.StaphylococcusAureus = userMood.StaphylococcusAureus;
                todaysGut.StreptococcusMinusThermophilusAndSalivarius = userMood.StreptococcusMinusThermophilusAndSalivarius;
                todaysGut.Veillonella = userMood.Veillonella;
                todaysGut.YersiniaEnterocolitica = userMood.YersiniaEnterocolitica;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutBadBacteria, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutBadBacteria, WasUpdated = false });
    }

    [HttpPost, Route(nameof(Component.GutConditionalBacteria))]
    public async Task<IActionResult> ManageGutConditionalBacteria(string email, string token, UserGutConditionalBacteria userMood)
    {
        if (true || ModelState.IsValid)
        {
            var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }

            // Set the new weight on the UserVariation
            var todaysGut = await _context.UserGutConditionalBacterias.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Date == DateHelpers.Today);
            if (todaysGut == null)
            {
                userMood.User = user;
                _context.Add(userMood);
            }
            else
            {
                todaysGut.RuminococcusBromii = userMood.RuminococcusBromii;
                todaysGut.Prevotella = userMood.Prevotella;
                todaysGut.Oscillibacter = userMood.Oscillibacter;
                todaysGut.Methanobacteria = userMood.Methanobacteria;
                todaysGut.Bacteroides = userMood.Bacteroides;
                todaysGut.Lactobacillus = userMood.Lactobacillus;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutConditionalBacteria, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageComponent), new { email, token, Component = Component.GutConditionalBacteria, WasUpdated = false });
    }
}
