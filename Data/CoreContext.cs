using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Data;

public class CoreContext : DbContext
{
    public DbSet<Footnote> Footnotes { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserToken> UserTokens { get; set; } = null!;
    public DbSet<UserComponent> UserComponents { get; set; } = null!;
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
    public DbSet<UserAgoraphobiaSeverity> UserAgoraphobiaSeverities { get; set; } = null!;
    public DbSet<UserAnger> UserAngers { get; set; } = null!;
    public DbSet<UserAnxiety> UserAnxieties { get; set; } = null!;
    public DbSet<UserDepressionSeverity> UserDepressionSeverities { get; set; } = null!;
    public DbSet<UserDissociativeSeverity> UserDissociativeSeverities { get; set; } = null!;
    public DbSet<UserGeneralizedAnxietySeverity> UserGeneralizedAnxietySeverities { get; set; } = null!;
    public DbSet<UserMania> UserManias { get; set; } = null!;
    public DbSet<UserPanicSeverity> UserPanicSeverities { get; set; } = null!;
    public DbSet<UserPosttraumaticStressSeverity> UserPosttraumaticStressSeverities { get; set; } = null!;
    public DbSet<UserSocialAnxietySeverity> UserSocialAnxietySeverities { get; set; } = null!;

    public CoreContext() : base() { }

    public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }

    private static readonly JsonSerializerOptions JsonSerializerOptions = new();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        //modelBuilder.Entity<ExerciseVariation>().HasKey(sc => new { sc.ExerciseId, sc.VariationId });

        //modelBuilder
        //    .Entity<Variation>()
        //    .Property(e => e.StrengthMuscles)
        //    .HasConversion(v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
        //        v => JsonSerializer.Deserialize<List<MuscleGroups>>(v, new JsonSerializerOptions()),
        //        new ValueComparer<List<MuscleGroups>>((mg, mg2) => mg == mg2, mg => mg.GetHashCode())
        //    );


        ////////// Query Filters //////////
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);
    }
}
