using Core.Models.User;
using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Allergens;

public class AllergensViewModel
{
    public AllergensViewModel(IList<UserAllergens>? userMoods, int chartDays = UserConsts.ChartDaysDefault)
    {
        if (userMoods != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                // Excluding complex allergens here so the graph has less data points and is easier to follow.
                return m.SimpleAllergens.Select(c => new UserCustomGroup(m.Date, c.Key.GetSingleDisplayName())
                {
                    Value = (int)c.Value
                }); // Only select allergens where there user has seen at least 1 over the duration.
            }).GroupBy(m => m.Name).Where(g => g.Any(m => m.Value > 0)).SelectMany(g => g).ToList();

            foreach (var days in Enumerable.Range(0, chartDays))
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
    public Data.Entities.Users.User User { get; init; } = null!;

    public required UserComponentSetting Setting { get; init; } = null!;
    public UserAllergens UserMood { get; init; } = null!;
    public UserAllergens? PreviousMood { get; init; }

    internal List<XyGroup> Xys { get; init; } = [];
    internal List<IGrouping<IGroup, XyGroup>> XysGrouped => Xys.Where(xy => xy.Y.HasValue).GroupBy(xy => xy.Group).ToList();
}
