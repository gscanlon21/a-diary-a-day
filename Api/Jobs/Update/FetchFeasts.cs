using Core.Code.Helpers;
using Core.Models.AFeastADay;
using Core.Models.Options;
using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quartz;

namespace Api.Jobs.Update;

[DisallowConcurrentExecution]
public class FetchFeasts : IJob, IScheduled
{
    private readonly UserRepo _userRepo;
    private readonly HttpClient _httpClient;
    private readonly ILogger<FetchFeasts> _logger;
    private readonly IOptions<SiteSettings> _siteSettings;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public FetchFeasts(ILogger<FetchFeasts> logger, UserRepo userRepo, IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _userRepo = userRepo;
        _siteSettings = siteSettings;
        _serviceScopeFactory = serviceScopeFactory;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != _siteSettings.Value.FeastUri)
        {
            _httpClient.BaseAddress = _siteSettings.Value.FeastUri;
        }
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            _logger.Log(LogLevel.Information, "Starting job {p0}", nameof(FetchFeasts));
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3, CancellationToken = context.CancellationToken };
            await Parallel.ForEachAsync(await GetUsers().ToListAsync(), options, async (userToken, cancellationToken) =>
            {
                try
                {
                    // The creation of DbContext is lightweight, and the context is not thread-safe.
                    using var scope = _serviceScopeFactory.CreateScope();
                    using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

                    var response = await _httpClient.GetAsync($"{_siteSettings.Value.FeastUri.AbsolutePath}/user/Allergens?weeks={1}&email={Uri.EscapeDataString(userToken.User.FeastEmail!)}&token={Uri.EscapeDataString(userToken.User.FeastToken!)}", cancellationToken);
                    var allergens = await ApiResult<IDictionary<Allergens, double>>.FromResponse(response);
                    if (!allergens.IsSuccessStatusCode)
                    {
                        _logger.Log(LogLevel.Warning, "Newsletter failed for user {Id} with status {StatusCode}", userToken.User.Id, allergens.StatusCode);
                    }

                    var startOfWeek = DateHelpers.Today.StartOfWeek();
                    var todaysMood = await context.UserAllergens.Where(p => p.UserId == userToken.User.Id && p.Date == startOfWeek).FirstOrDefaultAsync(cancellationToken);
                    if (todaysMood == null)
                    {
                        context.Add(new UserAllergens()
                        {
                            Date = startOfWeek,
                            UserId = userToken.User.Id,
                            Allergens = allergens.Value,
                        });
                    }
                    else
                    {
                        todaysMood.Allergens = allergens.Value;
                    }

                    await context.SaveChangesAsync(cancellationToken);
                }
                catch (Exception e)
                {
                    _logger.Log(LogLevel.Error, e, "Error retrieving newsletter for user {Id}", userToken.User.Id);
                }
            });
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error running job {p0}", nameof(FetchFeasts));
        }
        finally
        {
            _logger.Log(LogLevel.Information, "Ending job {p0}", nameof(FetchFeasts));
        }
    }

    internal async IAsyncEnumerable<(User User, string Token)> GetUsers()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var startOfWeek = DateHelpers.Today.StartOfWeek();
        foreach (var user in await context.Users.AsNoTracking()
            // User has confirmed their account.
            .Where(u => u.LastActive.HasValue)
            // User has not updated their feast allergens yet this week.
            .Where(u => !u.UserAllergens.Any(un => un.Date == startOfWeek))
            // User has entered feast email and token.
            .Where(u => !string.IsNullOrWhiteSpace(u.FeastEmail) && !string.IsNullOrWhiteSpace(u.FeastToken))
            // User is not a test or demo user.
            .Where(u => !u.Email.EndsWith(_siteSettings.Value.Domain) || u.Features.HasFlag(Features.Test) || u.Features.HasFlag(Features.Debug))
            .ToListAsync())
        {
            yield return (user, await _userRepo.AddUserToken(user, durationDays: 1));
        }
    }

    public static JobKey JobKey => new(nameof(FetchFeasts) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(FetchFeasts) + "Trigger", GroupName);
    public static string GroupName => "Update";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<FetchFeasts>()
            .WithIdentity(JobKey)
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity(TriggerKey)
            // https://www.freeformatter.com/cron-expression-generator-quartz.html
            .WithCronSchedule("0 0 0 ? * * *") // Every day
            .Build();

        if (await scheduler.GetTrigger(trigger.Key) != null)
        {
            // Update
            await scheduler.RescheduleJob(trigger.Key, trigger);
        }
        else
        {
            // Create
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
