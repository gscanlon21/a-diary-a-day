using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared;


public class RadarChartViewModel
{
    public const int Height = 350;

    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Component Type { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; init; } = null!;

    public IList<string> Labels => XysGrouped.OrderBy(g => g.Key.Order).Select(g => g.Key.Name).ToList();

    public IList<double> LastMonth => XysGrouped
        .OrderBy(g => g.Key.Order)
        .Select(g => g.Where(s => s?.Y?.Date.Month == DateHelpers.Today.AddMonths(-1).Month && s?.Y?.Date.Year == DateHelpers.Today.AddMonths(-1).Year).Sum(s => s?.Y?.One) ?? 0)
        .ToList();
    public IList<double> ThisMonth => XysGrouped
        .OrderBy(g => g.Key.Order)
        .Select(g => g.Where(s => s?.Y?.Date.Month == DateHelpers.Today.Month && s?.Y?.Date.Year == DateHelpers.Today.Year).Sum(s => s?.Y?.One) ?? 0)
        .ToList();
}
