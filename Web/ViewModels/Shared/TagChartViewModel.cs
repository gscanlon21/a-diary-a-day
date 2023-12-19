namespace Web.ViewModels.Shared;

public class TagChartViewModel
{
    public string Id { get; } = $"S{Guid.NewGuid():N}";

    internal List<IGrouping<int, XCustom>> XysGrouped { get; set; } = null!;

    public List<string> Ids = ["q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "i", "j", "k", "l", "z", "c", "v", "b", "n", "m"];
    public List<string> Colors = ["skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red"];
}
