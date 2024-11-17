﻿using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.Options;
using Core.Models.User;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
    /// Root route for building out the workout routine newsletter.
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
    /// Builds a new diary entry newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(NewsletterContext context)
    {
        var tasks = new List<QueryResults>(await GetUserTasks(context, Section.None));
        foreach (var section in EnumExtensions.GetSingleValues64<Section>())
        {
            tasks.AddRange(await GetUserTasks(context, section));
        }

        var newsletter = await CreateAndAddNewsletterToContext(context, tasks);
        var userViewModel = new UserNewsletterDto(context.User.AsType<UserDto, User>()!, context.Token);
        await UpdateLastSeenDate(tasks.Select(t => t.Task).Where(t => !t.PersistUntilComplete));

        return new NewsletterDto()
        {
            User = userViewModel,
            Verbosity = context.User.Verbosity,
            Images = GetImages(context.User).ToList(),
            UserDiary = newsletter.AsType<UserDiaryDto, UserDiary>()!,
            Tasks = tasks.Select(t => t.AsType<NewsletterTaskDto, QueryResults>()!).ToList(),
        };
    }

    /// <summary>
    /// Root route for building out the workout routine newsletter based on a date.
    /// </summary>
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, DateOnly date, UserDiary newsletter)
    {
        var tasks = new List<QueryResults>();
        foreach (var section in EnumExtensions.GetValuesExcluding32(Section.All))
        {
            tasks.AddRange((await new QueryBuilder(section)
                .WithUser(user, ignored: false)
                .WithTasks(options =>
                {
                    options.AddTasks(newsletter.UserDiaryTasks);
                })
                .Build()
                .Query(_serviceScopeFactory))
                // Re-order the tasks to match their original order.
                .OrderBy(vm => newsletter.UserDiaryTasks.FirstOrDefault(ut => ut.UserTaskId == vm.Task.Id && ut.Section == vm.Section)?.Order ?? vm.Task.Order));
        }

        // Only hide tasks for the current diary.
        if (date == user.TodayOffset)
        {
            // Hide tasks that we have already completed today.
            var taskLogs = await _context.UserTaskLogs.Where(utl => utl.Date == date).Where(utl => tasks.Select(t => t.Task.Id).Contains(utl.UserTaskId)).ToListAsync();
            tasks = tasks.Where(t => (taskLogs.FirstOrDefault(tl => tl.Section == t.Section && tl.UserTaskId == t.Task.Id)?.Complete ?? 0) == 0).ToList();
        }

        var images = GetImages(user).ToList();
        var userViewModel = new UserNewsletterDto(user.AsType<UserDto, User>()!, token);
        var newsletterViewModel = new NewsletterDto()
        {
            Today = date,
            Images = images,
            User = userViewModel,
            Verbosity = user.Verbosity,
            UserDiary = newsletter.AsType<UserDiaryDto, UserDiary>()!,
            Tasks = tasks.Select(r => r.AsType<NewsletterTaskDto, QueryResults>()!).ToList()
        };

        return newsletterViewModel;
    }

    private IEnumerable<ComponentImage> GetImages(User user)
    {
        var prefix = $"moods/{user.Uid}";
        var components = EnumExtensions.GetSingleValues64(excludingAny: Component.Journal | Component.Tasks);
        foreach (var component in components
            .OrderBy(c => c.GetSingleDisplayName(Core.Models.DisplayType.Order).Length)
            .ThenBy(c => c.GetSingleDisplayName(Core.Models.DisplayType.Order))
            .Where(c => user.Components.HasFlag(c)))
        {
            var key = $"{prefix}/{component}";
            yield return new ComponentImage()
            {
                Type = component,
                Image = $"{_siteSettings.Value.CdnLink}/{key}"
            };
        }
    }

    internal async Task<IList<QueryResults>> GetUserTasks(NewsletterContext newsletterContext, Section section, IEnumerable<QueryResults>? exclude = null)
    {
        if (!newsletterContext.User.Components.HasFlag(Component.Tasks))
        {
            return [];
        }

        return await new QueryBuilder(section)
            .WithUser(newsletterContext.User, ignored: false)
            .WithExcludeTasks(x =>
            {
                x.AddExcludeTasks(exclude?.Select(r => r.Task));
            })
            .Build()
            .Query(_serviceScopeFactory);
    }
}
