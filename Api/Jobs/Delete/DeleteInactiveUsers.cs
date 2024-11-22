using Amazon.S3;
using Amazon.S3.Model;
using Core.Code.Helpers;
using Core.Models.Options;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quartz;

namespace Api.Jobs.Delete;

/// <summary>
/// Deletes inactive accounts.
/// </summary>
public class DeleteInactiveUsers : IJob, IScheduled
{
    private readonly CoreContext _coreContext;
    private readonly ILogger<DeleteInactiveUsers> _logger;
    private readonly IOptions<SiteSettings> _siteSettings;
    private readonly Lazy<AmazonS3Client> _amazonS3Client;
    private readonly IOptions<DigitalOceanSettings> _digitalOceanOptions;

    public DeleteInactiveUsers(ILogger<DeleteInactiveUsers> logger, CoreContext coreContext, IOptions<SiteSettings> siteSettings, IOptions<DigitalOceanSettings> digitalOceanOptions)
    {
        _logger = logger;
        _coreContext = coreContext;
        _siteSettings = siteSettings;
        _digitalOceanOptions = digitalOceanOptions;
        _amazonS3Client = new Lazy<AmazonS3Client>(() => new AmazonS3Client(digitalOceanOptions.Value.AWSS3AccessKey, digitalOceanOptions.Value.AWSS3SecretKey, new AmazonS3Config()
        {
            ServiceURL = digitalOceanOptions.Value.CDNLink
        }));
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var userUidsToDelete = await _coreContext.Users.IgnoreQueryFilters()
                .Where(u => !u.Email.EndsWith(_siteSettings.Value.Domain))
                // User has not been active in the past X months.
                .Where(u => (u.LastActive != null && u.LastActive < DateHelpers.Today.AddMonths(-1 * UserConsts.DeleteAfterXMonths))
                    || (u.LastActive == null && u.CreatedDate < DateHelpers.Today.AddMonths(-1 * UserConsts.DeleteAfterXMonths))
                ).Select(u => u.Uid).ToListAsync();

            foreach (var userUidToDelete in userUidsToDelete)
            {
                // Delete inactive user images.
                var listResponse = await _amazonS3Client.Value.ListObjectsV2Async(new ListObjectsV2Request()
                {
                    BucketName = _digitalOceanOptions.Value.CDNBucket,
                    Prefix = $"moods/{userUidToDelete}/"
                });

                var deleteResponse = await _amazonS3Client.Value.DeleteObjectsAsync(new DeleteObjectsRequest()
                {
                    BucketName = _digitalOceanOptions.Value.CDNBucket,
                    Objects = listResponse.S3Objects.Select(obj => new KeyVersion() { Key = obj.Key }).ToList()
                });

                if (deleteResponse.DeleteErrors.Any())
                {
                    _logger.Log(LogLevel.Warning, "Delete objects for user {p0} failed with error {p1}.", userUidToDelete, deleteResponse.DeleteErrors.First());
                }
                else
                {
                    // Delete the user after the images have been deleted so we don't have orphaned images.
                    await _coreContext.Users.Where(u => u.Uid == userUidToDelete).ExecuteDeleteAsync();
                }
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Failed to delete users.");
        }
    }

    public static JobKey JobKey => new(nameof(DeleteInactiveUsers) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(DeleteInactiveUsers) + "Trigger", GroupName);
    public static string GroupName => "Delete";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<DeleteInactiveUsers>()
            .WithIdentity(JobKey)
            .Build();

        // Trigger the job every day
        var trigger = TriggerBuilder.Create()
            .WithIdentity(TriggerKey)
            .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 0))
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
