using Core.Models.User;
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
                return m.SimpleAllergens.Select(c => new UserCustomGroup(m.Date, c.Key.GetSingleDisplayName())
                {
                    Value = (int)c.Value
                });
            }).ToList();

            foreach (var days in Enumerable.Range(0, UserConsts.ChartDaysDefault))
            {
                var date = DateHelpers.Today.AddDays(-days);
                Xys.AddRange(flatMap.Where(f => f.Date == date).Select(item =>
                {
                    return new XyGroup(item, date, item.Value);
                }).Where(xy => xy.Y != null).Reverse());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserFeastAllergens UserMood { get; init; } = null!;
    public UserFeastAllergens? PreviousMood { get; init; }

    internal List<XyGroup> Xys { get; init; } = [];
    internal List<IGrouping<IGroup, XyGroup>> XysGrouped => Xys.Where(xy => xy.Y > 0).GroupBy(xy => xy.Group).ToList();
}
