using Data.Entities.Footnote;
using Data.Entities.User;
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
            SleepDurations = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new XYScore(date, (int?)userMoods.FirstOrDefault(uw => uw.Date == date)?.SleepDuration, userMoods.First().Items);
            }).Where(xy => xy.Y != null).Reverse().Append(new XYScore(Today, (int?)userMoods.FirstOrDefault(um => um.Date == Today)?.SleepDuration, userMoods.First().Items)).ToList();

            // Skip today, start at 1, because we append the current weight onto the end regardless.
            SleepTimes = Enumerable.Range(1, 365).Select(i =>
            {
                var date = Today.AddDays(-i);
                return new XYScore(date, (int?)userMoods.FirstOrDefault(uw => uw.Date == date)?.SleepTime, userMoods.First().Items);
            }).Where(xy => xy.Y != null).Reverse().Append(new XYScore(Today, (int?)userMoods.FirstOrDefault(um => um.Date == Today)?.SleepTime, userMoods.First().Items)).ToList();

            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Type, c.Id, c.Name));
            });

            foreach (var custom in Customs)
            {
                // Skip today, start at 1, because we append the current weight onto the end regardless.
                Xys.AddRange(Enumerable.Range(1, 365).Select(i =>
                {
                    var date = Today.AddDays(-i);
                    return new XCustom(date, flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id), custom.Id);
                }).Where(xy => xy.Y != null).Reverse().Append(new XCustom(Today, flatMap.FirstOrDefault(um => um.Date == Today && um.Id == custom.Id), custom.Id)).ToList());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserSleep UserMood { get; init; } = null!;

    internal List<XCustom> Xys { get; init; } = [];

    internal List<IGrouping<int, XCustom>> XysGrouped => Xys.GroupBy(xy => xy.Id).ToList();

    public List<UserCustom> Customs { get; set; } = [];

    internal IList<XYScore> SleepDurations { get; init; } = new List<XYScore>();
    internal IList<XYScore> SleepTimes { get; init; } = new List<XYScore>();
}
