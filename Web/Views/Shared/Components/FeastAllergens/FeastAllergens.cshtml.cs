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
                // Excluding complex allergens from here so the graph has less data points and is easier to follow.
                return m.SimpleAllergens.Select(c => new UserCustomGroup(m.Date, CustomType.None, (int)c.Key, c.Key.GetSingleDisplayName())
                {
                    One = (int)c.Value
                });
            }).ToList();

            foreach (var custom in customs)
            {
                Xys.AddRange(Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
                {
                    var date = DateHelpers.Today.AddDays(-i);
                    return new XCustom(date, flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id), custom);
                }).Where(xy => xy.Y != null).Reverse());
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
