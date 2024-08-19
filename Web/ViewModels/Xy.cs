using Core.Models.Footnote;
using Core.Models.User;
using Data.Entities.User;

namespace Web.ViewModels;

/// <summary>
/// For chart.js
/// </summary>
public record Xy(string X, double? Y, object? Extra)
{
    public Xy(string x, double? y) : this(x, y, null) { }
    public Xy(DateOnly x, double? y) : this(x.ToString("O"), y) { }
    public Xy(DateOnly x, double? y, object? extra) : this(x.ToString("O"), y, extra) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XCustom(string X, UserCustomGroup? Y, UserCustom Label)
{
    public XCustom(DateOnly x, UserCustomGroup? score, UserCustom label) : this(x.ToString("O"), score, label) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XScore(string X, IScore? Y, double? ProratedScore, double? AverageScore)
{
    public XScore(DateOnly x, IScore? score) : this(x.ToString("O"), score, score?.ProratedScore, score?.AverageScore) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XYScore(string X, double? Y, IList<int?> Items)
{
    public XYScore(DateOnly x, double? y, IList<int?> items) : this(x.ToString("O"), y, items) { }

    public int Total => Items.Count;

    public int Count => Items.Count(i => i.HasValue);
}

public record UserCustomGroup(DateOnly Date, CustomType Type, int Id, string Name)
{
    public int One { get; init; } = 1;
};