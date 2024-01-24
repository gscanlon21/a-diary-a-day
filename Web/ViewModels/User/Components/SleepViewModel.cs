using Core.Code.Extensions;
using Data.Entities.Footnote;
using Data.Entities.User;
using System.Linq;
using static Web.ViewModels.User.Components.ActivityViewModel;

namespace Web.ViewModels.User.Components;

public class SleepViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public SleepViewModel(IList<UserSleep>? userMoods, List<UserCustom> customs)
    {
        Customs = customs;
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && userMoods.Any())
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            var todaysDuration = userMoods.FirstOrDefault(um => um.Date == Today);
            SleepDurations = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                var userDuration = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userDuration?.SleepDuration, userDuration?.SleepDuration.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().Append(new Xy(Today, (int?)todaysDuration?.SleepDuration, todaysDuration?.SleepDuration.GetSingleDisplayName())).ToList();

            // Skip today, start at 1, because we append the current weight onto the end regardless.
            var todaysSleep = userMoods.FirstOrDefault(um => um.Date == Today);
            SleepTimes = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                var userSleep = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userSleep?.SleepTime, userSleep?.SleepTime.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().Append(new Xy(Today, (int?)todaysSleep?.SleepTime, todaysSleep?.SleepTime.GetSingleDisplayName())).ToList();

            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Type, c.Id, c.Name));
            });

            foreach (var custom in Customs)
            {
                var todaysCustom = flatMap.FirstOrDefault(um => um.Date == Today && um.Id == custom.Id);
                // Skip today, start at 1, because we append the current weight onto the end regardless.
                Xys.AddRange(Enumerable.Range(1, 365).Select(i =>
                {
                    var date = Today.AddDays(-i);
                    var userCustom = flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id);
                    return new XCustom(date, userCustom, custom);
                }).Where(xy => xy.Y != null).Reverse().Append(new XCustom(Today, todaysCustom, custom)).ToList());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserSleep UserMood { get; init; } = null!;

    internal List<XCustom> Xys { get; init; } = [];

    internal List<IGrouping<UserCustom, XCustom>> XysGrouped => Xys.GroupBy(xy => xy.Label).ToList();

    public List<UserCustom> Customs { get; set; } = [];

    internal IList<Xy> SleepDurations { get; init; } = new List<Xy>();
    internal IList<Xy> SleepTimes { get; init; } = new List<Xy>();
}
