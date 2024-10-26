using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.People;


public class PeopleViewModel
{
    public PeopleViewModel(IList<UserPeople>? userMoods, List<UserCustom> customs)
    {
        Customs = customs;

        if (userMoods != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Name));
            });

            foreach (var custom in Customs)
            {
                Xys.AddRange(Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
                {
                    var date = DateHelpers.Today.AddDays(-i);
                    return new XCustom(date, flatMap.FirstOrDefault(uw => uw.Date == date && uw.Name == custom.Name), custom);
                }).Where(xy => xy.Y != null).Reverse());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserPeople UserMood { get; init; } = null!;
    public UserPeople? PreviousMood { get; init; }

    internal List<XCustom> Xys { get; init; } = [];
    internal List<IGrouping<UserCustom, XCustom>> XysGrouped => Xys.GroupBy(xy => xy.Label).ToList();

    public List<UserCustom> Customs { get; set; } = [];
}
