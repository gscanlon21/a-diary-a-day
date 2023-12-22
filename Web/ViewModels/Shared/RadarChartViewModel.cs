namespace Web.ViewModels.Shared;

public class RadarChartViewModel
{
    public const int Height = 350;

    public string Id { get; } = $"S{Guid.NewGuid():N}";

    internal List<IGrouping<int, XCustom>> XysGrouped { get; set; } = null!;

    public IList<string> Labels => XysGrouped.OrderBy(g => g.Key).Select(g => g.FirstOrDefault()?.Y?.Name ?? "").ToList();

    public IList<int> LastMonth => XysGrouped
        .OrderBy(g => g.Key)
        .Select(g => g.Where(s => s?.Y?.Date.Month == Core.Dates.Today.AddMonths(-1).Month && s?.Y?.Date.Year == Core.Dates.Today.AddMonths(-1).Year).Sum(s => s?.Y?.One) ?? 0)
        .ToList();
    public IList<int> ThisMonth => XysGrouped
        .OrderBy(g => g.Key)
        .Select(g => g.Where(s => s?.Y?.Date.Month == Core.Dates.Today.Month && s?.Y?.Date.Year == Core.Dates.Today.Year).Sum(s => s?.Y?.One) ?? 0)
        .ToList();

    public List<string> Ids = ["q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "i", "j", "k", "l", "z", "c", "v", "b", "n", "m"];
    public List<string> Colors = ["skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red", "skyblue", "red"];
}
