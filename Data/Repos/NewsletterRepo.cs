using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.Options;
using Core.Models.User;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
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

        // Is the user requesting an old newsletter? Newsletters are weekly so shimmy the date over to the start of the week.
        date ??= user.TodayOffset;
        var oldNewsletter = await _context.UserDiaries.AsNoTracking()
            .Include(n => n.UserDiaryTasks)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date == date)
            // Always send a new newsletter for the demo and test users.
            .Where(n => !user.Features.HasFlag(Features.Demo) && !user.Features.HasFlag(Features.Test))
            .OrderByDescending(n => n.Id)
            .FirstOrDefaultAsync();

        // A newsletter was found.
        if (oldNewsletter != null)
        {
            _logger.Log(LogLevel.Information, "Returning old newsletter for user {Id}", user.Id);
            return await NewsletterOld(user, token, date.Value, oldNewsletter);
        }
        // A newsletter was not found and the date is not one we want to render a new newsletter for.
        else if (date != user.TodayOffset)
        {
            _logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
            return null;
        }

        // Context may be null on rest days.
        var newsletterContext = await BuildNewsletterContext(user, token);
        if (newsletterContext == null)
        {
            // See if a previous workout exists, we send that back down so the app doesn't render nothing on rest days.
            var currentFeast = await _userRepo.GetCurrentDiary(user);
            if (currentFeast == null)
            {
                _logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }

            _logger.Log(LogLevel.Information, "Returning current newsletter for user {Id}", user.Id);
            return await NewsletterOld(user, token, currentFeast.Date, currentFeast);
        }

        // User is a debug user. They should see the DebugNewsletter instead.
        if (user.Features.HasFlag(Features.Debug))
        {
            _logger.Log(LogLevel.Information, "Returning debug newsletter for user {Id}", user.Id);
            return null;//await Debug(newsletterContext);
        }

        _logger.Log(LogLevel.Information, "Returning on day newsletter for user {Id}", user.Id);
        return await OnDayNewsletter(newsletterContext);
    }

    /// <summary>
    /// The strength training newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(NewsletterContext context)
    {
        var userViewModel = new UserNewsletterDto(context.User.AsType<UserDto, User>()!, context.Token);

        var morningTasks = await GetUserMorningTasks(context);
        var middayTasks = await GetUserMiddayTasks(context);
        var nightTasks = await GetUserNightTasks(context);
        var anytimeTasks = await GetUserAnytimeTasks(context);
        var allTasks = morningTasks.Concat(middayTasks).Concat(nightTasks).Concat(anytimeTasks).ToList();

        var images = GetImages(context.User).ToList();
        var newsletter = await CreateAndAddNewsletterToContext(context, allTasks);
        await UpdateLastSeenDate(allTasks);
        var viewModel = new NewsletterDto(userViewModel)
        {
            Images = images,
            Tasks = allTasks.Select(t => t.AsType<NewsletterTaskDto, QueryResults>()!).ToList(),
        };

        return viewModel;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter based on a date.
    /// </summary>
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, DateOnly date, UserDiary newsletter)
    {
        List<QueryResults> tasks = [];
        foreach (var section in EnumExtensions.GetSingleOrNoneValues32<Section>())
        {
            tasks.AddRange((await new QueryBuilder(section)
                .WithUser(user)
                .WithTasks(options =>
                {
                    options.AddTasks(newsletter.UserDiaryTasks);
                })
                .Build()
                .Query(_serviceScopeFactory))
                // Re-order the recipes to match their original order.
                // May be null when the user substitutes in a recipe for an ingredient after the first feast was sent.
                .OrderBy(e => newsletter.UserDiaryTasks.FirstOrDefault(nv => nv.UserTaskId == e.Task.Id)?.Order ?? -1));
        }

        var images = GetImages(user).ToList();
        var userViewModel = new UserNewsletterDto(user.AsType<UserDto, User>()!, token);
        var newsletterViewModel = new NewsletterDto(userViewModel)
        {
            Today = date,
            Images = images,
            Tasks = tasks.Select(r => r.AsType<NewsletterTaskDto, QueryResults>()!).ToList()
        };

        return newsletterViewModel;
    }

    private IEnumerable<ComponentImage> GetImages(User user)
    {
        var prefix = $"moods/{user.Uid}";
        var components = EnumExtensions.GetSingleValuesExcludingAny32(Components.Journal).Where(c => user.Components.HasFlag(c)).ToList();
        foreach (var component in components)
        {
            var key = $"{prefix}-{component}";
            yield return new ComponentImage()
            {
                Type = component,
                Image = $"{_siteSettings.Value.CdnLink}/{key}"
            };
        }
    }

    internal async Task<IList<QueryResults>> GetUserMorningTasks(NewsletterContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        return await new QueryBuilder(Section.Morning)
            .WithUser(newsletterContext.User)
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeTasks(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetUserMiddayTasks(NewsletterContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        return await new QueryBuilder(Section.Midday)
            .WithUser(newsletterContext.User)
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeTasks(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetUserNightTasks(NewsletterContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        return await new QueryBuilder(Section.Night)
            .WithUser(newsletterContext.User)
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeTasks(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetUserAnytimeTasks(NewsletterContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        return await new QueryBuilder(Section.None)
            .WithUser(newsletterContext.User)
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeTasks(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }
}
