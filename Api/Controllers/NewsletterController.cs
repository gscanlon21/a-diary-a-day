using Core.Consts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public partial class NewsletterController : ControllerBase
{
    private readonly UserRepo _userRepo;
    private readonly NewsletterRepo _newsletterRepo;

    public NewsletterController(NewsletterRepo newsletterRepo, UserRepo userRepo)
    {
        _userRepo = userRepo;
        _newsletterRepo = newsletterRepo;
    }

    [HttpGet("Footnotes")]
    public async Task<IActionResult> GetFootnotes(string? email = null, string? token = null, int count = 1)
    {
        var footnotes = await _newsletterRepo.GetFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    [HttpGet("Footnotes/Custom")]
    public async Task<IActionResult> GetUserFootnotes(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, int count = 1)
    {
        var footnotes = await _newsletterRepo.GetUserFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    /// <summary>
    /// Root route for building out the workout routine newsletter.
    /// </summary>
    [HttpGet("Newsletter")]
    public async Task<IActionResult?> GetNewsletter(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, DateOnly? date = null)
    {
        try
        {
            var newsletter = await _newsletterRepo.Newsletter(email, token, date);
            if (newsletter != null)
            {
                return StatusCode(StatusCodes.Status200OK, newsletter);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (UserException)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }

    /// <summary>
    /// Get the user's past newsletters.
    /// </summary>
    [HttpGet("Newsletters")]
    public async Task<IActionResult> GetNewsletters(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        try
        {
            var user = await _userRepo.GetUserStrict(email, token);
            var diaries = await _userRepo.GetPastDiaries(user);
            if (diaries != null)
            {
                return StatusCode(StatusCodes.Status200OK, diaries);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (UserException)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}
