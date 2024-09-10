using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared;

public class LineChartViewModel
{
    public const int Height = 350;

    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Component Type { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; init; } = null!;

    public IList<string> Labels => XysGrouped.OrderBy(g => g.Key.Order).Select(g => g.Key.Name).ToList();
}
