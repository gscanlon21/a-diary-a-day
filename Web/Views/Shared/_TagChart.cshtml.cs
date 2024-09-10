using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared;

public class TagChartViewModel
{
    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Component Type { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; set; } = null!;
}
