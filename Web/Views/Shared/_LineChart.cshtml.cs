using Core.Models.User;
using Web.ViewModels;

namespace Web.Views.Shared;

public class LineChartViewModel : ChartViewModel
{
    public const int Height = 350;

    public List<IGrouping<IGroup, XyGroup>> XysGrouped { get; init; } = null!;

    public IList<string> Labels => XysGrouped.OrderBy(g => g.Key.Order).Select(g => g.Key.Name).ToList();
}
