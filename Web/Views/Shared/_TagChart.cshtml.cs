using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared;

public class TagChartViewModel
{
    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Core.Models.User.Components Type { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required List<IGrouping<UserCustom, XCustom>> XysGrouped { get; set; } = null!;

    public List<string> Ids = ["q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "i", "j", "k", "l", "z", "c", "v", "b", "n", "m"];
    public List<string> Colors = ["skyblue", "red", "orange", "green", "purple", "skyblue", "red", "orange", "green", "purple", "skyblue", "red", "orange", "green", "purple", "skyblue", "red", "orange", "green", "purple", "skyblue", "red", "orange", "green", "purple"];
}
