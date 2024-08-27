using Core.Models.Footnote;
using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.FeastAllergens;

public class FeastAllergensViewModel
{
    public FeastAllergensViewModel(IList<UserFeastAllergens>? userMoods, List<UserCustom> customs)
    {
        if (userMoods != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                return m.Allergens.Select(c => new UserCustomGroup(m.Date, CustomType.None, (int)c.Key, c.Key.GetSingleDisplayName())
                {
                    One = (int)c.Value
                });
            });

            foreach (var custom in customs)
            {
                // Skip today, start at 1, because we append the current weight onto the end regardless.
                Xys.AddRange(Enumerable.Range(1, UserConsts.ChartDaysDefault).Select(i =>
                {
                    var date = DateHelpers.Today.AddDays(-i);
                    return new XCustom(date, flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id), custom);
                }).Where(xy => xy.Y != null).Reverse().Append(new XCustom(DateHelpers.Today, flatMap.FirstOrDefault(um => um.Date == DateHelpers.Today && um.Id == custom.Id), custom)).ToList());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserFeastAllergens UserMood { get; init; } = null!;
    public UserFeastAllergens? PreviousMood { get; init; }

    internal List<XCustom> Xys { get; init; } = [];
    internal List<IGrouping<UserCustom, XCustom>> XysGrouped => Xys.Where(xy => xy.Y?.One > 0).GroupBy(xy => xy.Label).ToList();
}
