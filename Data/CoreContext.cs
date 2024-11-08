using Core.Models.AFeastADay;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.Task;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Data;

public class CoreContext : DbContext
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new();

    [Obsolete("Public parameterless constructor required for EF Core.", error: true)]
    public CoreContext() : base() { }

    public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserToken> UserTokens { get; set; } = null!;
    public DbSet<UserTask> UserTasks { get; set; } = null!;
    public DbSet<UserTaskLog> UserTaskLogs { get; set; } = null!;
    public DbSet<UserDiary> UserDiaries { get; set; } = null!;
    public DbSet<UserDiaryTask> UserDiaryTasks { get; set; } = null!;
    public DbSet<UserComponent> UserComponents { get; set; } = null!;
    public DbSet<UserComponentSetting> UserComponentSettings { get; set; } = null!;
    public DbSet<UserEmail> UserEmails { get; set; } = null!;
    public DbSet<UserMood> UserMoods { get; set; } = null!;
    public DbSet<UserEmotion> UserEmotions { get; set; } = null!;
    public DbSet<UserDepression> UserDepressions { get; set; } = null!;
    public DbSet<UserJournal> UserJournals { get; set; } = null!;
    public DbSet<UserFootnote> UserFootnotes { get; set; } = null!;
    public DbSet<UserAcuteStressSeverity> UserAcuteStressSeverities { get; set; } = null!;
    public DbSet<UserCustom> UserCustoms { get; set; } = null!;
    public DbSet<UserSymptom> UserSymptoms { get; set; } = null!;
    public DbSet<UserPeople> UserPeoples { get; set; } = null!;
    public DbSet<UserMedicine> UserMedicines { get; set; } = null!;
    public DbSet<UserSleep> UserSleeps { get; set; } = null!;
    public DbSet<UserActivity> UserActivities { get; set; } = null!;
    public DbSet<UserDryEyes> UserDryEyes { get; set; } = null!;
    public DbSet<UserFeastAllergens> UserFeastAllergens { get; set; } = null!;
    public DbSet<UserAgoraphobiaSeverity> UserAgoraphobiaSeverities { get; set; } = null!;
    public DbSet<UserCompleteMetabolicPanel> UserCompleteMetabolicPanels { get; set; } = null!;
    public DbSet<UserCbcWAutoDiff> UserCbcWAutoDiffs { get; set; } = null!;
    public DbSet<UserBloodWork> UserBloodWorks { get; set; } = null!;
    public DbSet<UserAnger> UserAngers { get; set; } = null!;
    public DbSet<UserAnxiety> UserAnxieties { get; set; } = null!;
    public DbSet<UserDepressionSeverity> UserDepressionSeverities { get; set; } = null!;
    public DbSet<UserDissociativeSeverity> UserDissociativeSeverities { get; set; } = null!;
    public DbSet<UserGeneralizedAnxietySeverity> UserGeneralizedAnxietySeverities { get; set; } = null!;
    public DbSet<UserGutShortChainFattyAcids> UserGutShortChainFattyAcids { get; set; } = null!;
    public DbSet<UserGutPathogens> UserGutPathogens { get; set; } = null!;
    public DbSet<UserGutProbiotics> UserGutProbiotics { get; set; } = null!;
    public DbSet<UserGutMicronutrients> UserGutMicronutrients { get; set; } = null!;
    public DbSet<UserGutConditionalBacteria> UserGutConditionalBacterias { get; set; } = null!;
    public DbSet<UserGutGoodBacteria> UserGutGoodBacterias { get; set; } = null!;
    public DbSet<UserGutBadBacteria> UserGutBadBacterias { get; set; } = null!;
    public DbSet<UserGutPillars> UserGutPillars { get; set; } = null!;
    public DbSet<UserGutFungi> UserGutFungi { get; set; } = null!;
    public DbSet<UserMania> UserManias { get; set; } = null!;
    public DbSet<UserPanicSeverity> UserPanicSeverities { get; set; } = null!;
    public DbSet<UserPostTraumaticStressSeverity> UserPostTraumaticStressSeverities { get; set; } = null!;
    public DbSet<UserSocialAnxietySeverity> UserSocialAnxietySeverities { get; set; } = null!;
    public DbSet<Footnote> Footnotes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserComponentSetting>().HasKey(sc => new { sc.UserId, sc.Component });

        ////////// Query Filters //////////
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);

        ////////// Conversions //////////
        modelBuilder.Entity<UserFeastAllergens>().Property(e => e.Allergens).HasConversion(v => JsonSerializer.Serialize(v, JsonSerializerOptions),
            v => JsonSerializer.Deserialize<Dictionary<string, double>>(v, JsonSerializerOptions)!.Where(kv => Enum.IsDefined(typeof(Allergens), kv.Key)).ToDictionary(kv => Enum.Parse<Allergens>(kv.Key), kv => kv.Value),
            new ValueComparer<IDictionary<Allergens, double>>((mg, mg2) => mg == mg2, mg => mg.GetHashCode()));
    }
}
