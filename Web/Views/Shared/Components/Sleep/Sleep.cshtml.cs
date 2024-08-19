using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Sleep;

public class SleepViewModel
{
    public SleepViewModel(IList<UserSleep>? userMoods, List<UserCustom> customs)
    {
        Customs = customs;
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && userMoods.Any())
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            var todaysDuration = userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today);
            SleepDurations = Enumerable.Range(1, 365).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                var userDuration = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userDuration?.SleepDuration, userDuration?.SleepDuration.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().Append(new Xy(DateHelpers.Today, (int?)todaysDuration?.SleepDuration, todaysDuration?.SleepDuration.GetSingleDisplayName())).ToList();

            // Skip today, start at 1, because we append the current weight onto the end regardless.
            var todaysSleep = userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today);
            SleepTimes = Enumerable.Range(1, 365).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                var userSleep = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userSleep?.SleepTime, userSleep?.SleepTime.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().Append(new Xy(DateHelpers.Today, (int?)todaysSleep?.SleepTime, todaysSleep?.SleepTime.GetSingleDisplayName())).ToList();

            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Type, c.Id, c.Name));
            });

            foreach (var custom in Customs)
            {
                var todaysCustom = flatMap.FirstOrDefault(um => um.Date == DateHelpers.Today && um.Id == custom.Id);
                // Skip today, start at 1, because we append the current weight onto the end regardless.
                Xys.AddRange(Enumerable.Range(1, 365).Select(i =>
                {
                    var date = DateHelpers.Today.AddDays(-i);
                    var userCustom = flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id);
                    return new XCustom(date, userCustom, custom);
                }).Where(xy => xy.Y != null).Reverse().Append(new XCustom(DateHelpers.Today, todaysCustom, custom)).ToList());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserSleep UserMood { get; init; } = null!;

    internal List<XCustom> Xys { get; init; } = [];

    internal List<IGrouping<UserCustom, XCustom>> XysGrouped => Xys.GroupBy(xy => xy.Label).ToList();

    public List<UserCustom> Customs { get; set; } = [];

    internal IList<Xy> SleepDurations { get; init; } = [];
    internal IList<Xy> SleepTimes { get; init; } = [];
}
