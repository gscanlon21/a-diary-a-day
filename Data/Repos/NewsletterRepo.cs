using Core.Models.Footnote;
using Data.Dtos.Newsletter;
using Data.Dtos.User;
using Data.Entities.Footnote;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Core.Code.Extensions;
using Core.Models.User;
using Microsoft.Extensions.Options;
using Core.Models.Options;

namespace Data.Repos;

public partial class NewsletterRepo(ILogger<NewsletterRepo> logger, CoreContext context, UserRepo userRepo, IOptions<SiteSettings> siteSettings, IServiceScopeFactory serviceScopeFactory)
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// This week's Sunday date in UTC.
    /// </summary>
    protected static DateOnly StartOfWeek => Today.AddDays(-1 * (int)Today.DayOfWeek);

    private readonly CoreContext _context = context;

    public async Task<IList<Footnote>> GetFootnotes(string? email, string? token, int count = 1)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        var footnotes = await _context.Footnotes
            // Apply the user's footnote type preferences. Has any flag.
            .Where(f => user == null || (f.Type & user.FootnoteType) != 0)
            .OrderBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        return footnotes;
    }

    public async Task<IList<UserFootnote>> GetUserFootnotes(string? email, string? token, int count = 1)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        ArgumentNullException.ThrowIfNull(user);
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return new List<UserFootnote>(0);
        }

        var footnotes = await _context.UserFootnotes
            .Where(f => f.Type == FootnoteType.Custom)
            .Where(f => f.UserId == user.Id)
            // Keep the same footnotes over the course of a day.
            .OrderByDescending(f => f.UserLastSeen == Today)
            // Then choose the least seen.
            .ThenBy(f => f.UserLastSeen)
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        foreach (var footnote in footnotes)
        {
            footnote.UserLastSeen = Today;
        }

        await _context.SaveChangesAsync();
        return footnotes;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return null;
        }

        logger.Log(LogLevel.Information, "Building newsletter for user {Id}", user.Id);

        // Is the user requesting an old newsletter?
        date ??= user.TodayOffset;
        if (date.HasValue)
        {
            // A newsletter was not found and the date is not one we want to render a new newsletter for.
            if (date != user.TodayOffset)
            {
                logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }
            // Else continue on to render a new newsletter for today.
        }

        // Context may be null on rest days.
        var context = await BuildWorkoutContext(user, token);
        if (context == null)
        {
            return null;
        }

        logger.Log(LogLevel.Information, "Returning on day newsletter for user {Id}", user.Id);
        return await OnDayNewsletter(context);
    }

    /// <summary>
    /// The strength training newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(WorkoutContext context)
    {
        var userViewModel = new UserNewsletterDto(context);

        var images = new List<ComponentImage>();
        var prefix = $"moods/{context.User.Uid}";
        var components = EnumExtensions.GetSingleValuesExcludingAny32(Components.Journal).Where(c => context.User.Components.HasFlag(c)).ToList();
        foreach (var component in components)
        {
            var key = $"{prefix}-{component}";
            images.Add(new ComponentImage() 
            { 
                Type = component,
                Image = $"{siteSettings.Value.CdnLink}/{key}"
            });
        }

        var viewModel = new NewsletterDto(userViewModel)
        {
            Images = images,
        };

        return viewModel;
    }
}
