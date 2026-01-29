using Data.Entities.Users;
using Web.ViewModels;

namespace Web.Views.Shared;

public class TagChartViewModel : ChartViewModel
{
    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; set; } = null!;
}
