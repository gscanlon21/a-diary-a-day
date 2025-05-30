using Core.Models.User;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Web.ViewModels;

namespace Web.Views.Shared.Components.GutMicronutrients;

public class GutMicronutrientsViewModel
{
    public GutMicronutrientsViewModel(IList<UserGutMicronutrients>? userMoods, List<UserCustom>? customs)
    {
        if (userMoods != null && customs != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                return m.Items.Select(c => new UserCustomGroup(m.Date, c.Key)
                {
                    Value = c.Value ?? 0,
                    Description = typeof(UserGutMicronutrients).GetProperty(c.Key)!.GetCustomAttribute<DisplayAttribute>()!.Description
                });
            });

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

    public UserGutMicronutrients UserMood { get; init; } = null!;
    public UserGutMicronutrients? PreviousMood { get; init; }

    internal List<XyGroup> Xys { get; init; } = [];
    internal List<IGrouping<IGroup, XyGroup>> XysGrouped => Xys.Where(xy => xy.Y > 0).GroupBy(xy => xy.Group).ToList();
}
