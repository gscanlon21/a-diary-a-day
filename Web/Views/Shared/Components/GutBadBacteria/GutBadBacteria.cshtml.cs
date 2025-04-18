using Core.Attributes;
using Core.Models.User;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Web.ViewModels;

namespace Web.Views.Shared.Components.GutBadBacteria;

public class GutBadBacteriaViewModel
{
    public GutBadBacteriaViewModel(IList<UserGutBadBacteria>? userMoods, List<UserCustom>? customs)
    {
        var lowRiskAttributes = typeof(UserGutBadBacteria).GetProperties().ToDictionary(p => p.Name,
            p => p.GetCustomAttributes<IdealRangeAttribute>().Where(a => a.RiskType == RiskType.LowRisk));

        if (userMoods != null && customs != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                return m.Items.Select(c => new UserCustomGroup(m.Date, c.Key)
                {
                    Value = c.Value ?? 0,
                    Description = typeof(UserGutBadBacteria).GetProperty(c.Key)!.GetCustomAttribute<DisplayAttribute>()!.Description
                });
            }).GroupBy(m => m.Name).Where(g => !g.All(i => lowRiskAttributes[g.Key].Any(a => a.IsInRange(i.Value)))).SelectMany(g => g);

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

    public UserGutBadBacteria UserMood { get; init; } = null!;
    public UserGutBadBacteria? PreviousMood { get; init; }

    internal List<XyGroup> Xys { get; init; } = [];
    internal List<IGrouping<IGroup, XyGroup>> XysGrouped => Xys.Where(xy => xy.Y > 0).GroupBy(xy => xy.Group).ToList();
}
