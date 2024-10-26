using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Sleep;

public class SleepViewModel
{
    public SleepViewModel(IList<UserSleep>? userMoods, List<UserCustom> customs)
    {
        Customs = customs;
        if (userMoods != null && userMoods.Any())
        {
            var todaysDuration = userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today);
            SleepDurations = Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                var userDuration = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userDuration?.SleepDuration, userDuration?.SleepDuration.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().ToList();

            var todaysSleep = userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today);
            SleepTimes = Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                var userSleep = userMoods.FirstOrDefault(uw => uw.Date == date);
                return new Xy(date, (int?)userSleep?.SleepTime, userSleep?.SleepTime.GetSingleDisplayName());
            }).Where(xy => xy.Y != null).Reverse().ToList();

            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Name));
            });

            foreach (var custom in Customs)
            {
                var todaysCustom = flatMap.FirstOrDefault(um => um.Date == DateHelpers.Today && um.Name == custom.Name);
                Xys.AddRange(Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
                {
                    var date = DateHelpers.Today.AddDays(-i);
                    var userCustom = flatMap.FirstOrDefault(uw => uw.Date == date && uw.Name == custom.Name);
                    return new XCustom(date, userCustom, custom);
                }).Where(xy => xy.Y != null).Reverse());
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
