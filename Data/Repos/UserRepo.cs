using Core.Code.Exceptions;
using Core.Consts;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Data.Repos;

/// <summary>
/// User helpers.
/// </summary>
public class UserRepo(CoreContext context)
{
    private readonly CoreContext _context = context;

    /// <summary>
    /// Grab a user from the db with a specific token.
    /// </summary>
    public async Task<User> GetUserStrict(string? email, string? token, bool includeSettings = false, bool allowDemoUser = false)
    {
        return await GetUser(email, token, includeSettings: includeSettings, allowDemoUser: allowDemoUser) ?? throw new UserException("User is null.");
    }

    /// <summary>
    /// Grab a user from the db with a specific token.
    /// </summary>
    public async Task<User?> GetUser(string? email, string? token, bool includeSettings = false, bool allowDemoUser = false)
    {
        if (email == null || token == null)
        {
            return null;
        }

        IQueryable<User> query = _context.Users.AsSplitQuery().TagWithCallSite();

        if (includeSettings)
        {
            query = query.Include(u => u.UserComponentSettings);
        }

        var user = await query
            // User token is valid.
            .Where(u => u.UserTokens.Any(ut => ut.Token == token && ut.Expires > DateTime.UtcNow))
            .FirstOrDefaultAsync(u => u.Email == email);

        if (!allowDemoUser && user?.IsDemoUser == true)
        {
            throw new UserException("User not authorized.");
        }

        return user;
    }

    private static string CreateToken(int count = 24) => Convert.ToBase64String(RandomNumberGenerator.GetBytes(count));
    public async Task<string> AddUserToken(User user, int durationDays = 1) => await AddUserToken(user, DateTime.UtcNow.AddDays(durationDays));
    public async Task<string> AddUserToken(User user, DateTime expires)
    {
        if (user.IsDemoUser)
        {
            return UserConsts.DemoToken;
        }

        var token = CreateToken();
        _context.UserTokens.Add(new UserToken(user, token)
        {
            Expires = expires
        });

        await _context.SaveChangesAsync();
        return token;
    }

    /// <summary>
    /// Get the user's current feast.
    /// </summary>
    public async Task<UserDiary?> GetCurrentDiary(User user)
    {
        return await _context.UserDiaries.AsNoTracking().TagWithCallSite()
            .Include(uw => uw.UserDiaryTasks)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date <= user.TodayOffset)
            // For testing/demo. When two newsletters get sent in the same day, I want a different exercise set.
            // Dummy records that are created when the user advances their workout split may also have the same date.
            .OrderByDescending(n => n.Date)
            .ThenByDescending(n => n.Id)
            .FirstOrDefaultAsync();
    }


    /// <summary>
    /// Get the last 7 days of newsletters for the user. Excludes the current newsletter.
    /// </summary>
    public async Task<IList<PastDiary>> GetPastDiaries(User user)
    {
        return await _context.UserDiaries
            .Where(uw => uw.UserId == user.Id)
            .Where(n => n.Date < user.TodayOffset)
            // Select the most recent diary per day. Order after grouping.
            .GroupBy(n => n.Date).OrderByDescending(n => n.Key)
            // Can't be passed through the constructor or it's slow.
            .Select(g => new PastDiary() { Date = g.OrderByDescending(n => n.Id).First().Date })
            .Take(7).IgnoreQueryFilters().AsNoTracking()
            .ToListAsync();
    }
}

