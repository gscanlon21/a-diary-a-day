using Core.Models.Footnote;
using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.GutMicronutrients;

public class GutMicronutrientsViewModel
{
    public GutMicronutrientsViewModel(IList<UserGutMicronutrients>? userMoods, List<UserCustom>? customs)
    {
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null && customs != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                // Excluding complex allergens from here so the graph has less data points and is easier to follow.
                return m.Items.Select(c => new UserCustomGroup(m.Date, CustomType.None, 0, c.Key)
                {
                    One = c.Value ?? 0
                });
            });

            foreach (var custom in customs)
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

    public UserGutMicronutrients UserMood { get; init; } = null!;
    public UserGutMicronutrients? PreviousMood { get; init; }

    internal List<XCustom> Xys { get; init; } = [];
    internal List<IGrouping<UserCustom, XCustom>> XysGrouped => Xys.Where(xy => xy.Y?.One > 0).GroupBy(xy => xy.Label).ToList();
}
