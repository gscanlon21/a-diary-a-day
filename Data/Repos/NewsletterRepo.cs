using Core.Code.Extensions;
using Core.Code.Helpers;
using Core.Dtos.Newsletter;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.Options;
using Core.Models.User;
using Data.Dtos.Newsletter;
using Data.Dtos.User;
using Data.Entities.Footnote;
using Data.Models;
using Data.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Code;

namespace Data.Repos;

public partial class NewsletterRepo
{
    private readonly CoreContext _context;
    private readonly ILogger<NewsletterRepo> _logger;
    private readonly UserRepo _userRepo;
    private readonly IOptions<SiteSettings> _siteSettings;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NewsletterRepo(ILogger<NewsletterRepo> logger, IServiceScopeFactory serviceScopeFactory, CoreContext context, UserRepo userRepo, IOptions<SiteSettings> siteSettings)
    {
        _context = context;
        _logger = logger;
        _userRepo = userRepo;
        _siteSettings = siteSettings;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IList<Footnote>> GetFootnotes(string? email, string? token, int count = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
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
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        ArgumentNullException.ThrowIfNull(user);
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return [];
        }

        var footnotes = await _context.UserFootnotes
            .Where(f => f.Type == FootnoteType.Custom)
            .Where(f => f.UserId == user.Id)
            // Keep the same footnotes over the course of a day.
            .OrderByDescending(f => f.UserLastSeen == DateHelpers.Today)
            // Then choose the least seen.
            .ThenBy(f => f.UserLastSeen)
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        foreach (var footnote in footnotes)
        {
            footnote.UserLastSeen = DateHelpers.Today;
        }

        await _context.SaveChangesAsync();
        return footnotes;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return null;
        }

        _logger.Log(LogLevel.Information, "Building newsletter for user {Id}", user.Id);

        // Is the user requesting an old newsletter?
        date ??= user.TodayOffset;
        if (date.HasValue)
        {
            // A newsletter was not found and the date is not one we want to render a new newsletter for.
            if (date != user.TodayOffset)
            {
                _logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }
            // Else continue on to render a new newsletter for today.
        }

        // Context may be null on rest days.
        var context = await BuildNewsletterContext(user, token);
        if (context == null)
        {
            return null;
        }

        _logger.Log(LogLevel.Information, "Returning on day newsletter for user {Id}", user.Id);
        return await OnDayNewsletter(context);
    }

    /// <summary>
    /// The strength training newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(NewsletterContext context)
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
                Image = $"{_siteSettings.Value.CdnLink}/{key}"
            });
        }

        var tasks = await GetUserTasks(context);
        var newsletter = await CreateAndAddNewsletterToContext(context, tasks);
        await UpdateLastSeenDate(tasks);
        var viewModel = new NewsletterDto(userViewModel)
        {
            Images = images,
            Tasks = tasks.Select(t => t.AsType<NewsletterTaskDto, QueryResults>()!).ToList(),
        };

        return viewModel;
    }

    internal async Task<IList<QueryResults>> GetUserTasks(NewsletterContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        return await new QueryBuilder(Section.None)
            .WithUser(newsletterContext.User)
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }
}
