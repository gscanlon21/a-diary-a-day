using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared;

public class RadarChartViewModel : ChartViewModel
{
    public const int Height = 350;

    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; init; } = null!;

    public IList<string> Labels => XysGrouped.OrderBy(g => g.Key.Order).Select(g => g.Key.Name).ToList();

    public IList<double> LastMonth => XysGrouped
        .OrderBy(g => g.Key.Order)
        .Select(g => g.Where(s => s?.Y?.Date.Month == DateHelpers.Today.AddMonths(-1).Month && s?.Y?.Date.Year == DateHelpers.Today.AddMonths(-1).Year).Sum(s => s?.Y?.Value) ?? 0)
        .ToList();
    public IList<double> ThisMonth => XysGrouped
        .OrderBy(g => g.Key.Order)
        .Select(g => g.Where(s => s?.Y?.Date.Month == DateHelpers.Today.Month && s?.Y?.Date.Year == DateHelpers.Today.Year).Sum(s => s?.Y?.Value) ?? 0)
        .ToList();
}
