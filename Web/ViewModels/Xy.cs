using Core.Models.User;
using Data.Entities.Footnote;
using static Web.ViewModels.User.Components.ActivityViewModel;

namespace Web.ViewModels;

/// <summary>
/// For chart.js
/// </summary>
public record Xy(string X, int? Y)
{
    public Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
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
public record XScore(string X, IScore? Y, int? ProratedScore, int? AverageScore)
{
    public XScore(DateOnly x, IScore? score) : this(x.ToString("O"), score, score?.ProratedScore, score?.AverageScore) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XYScore(string X, int? Y, IList<int?> Items)
{
    public XYScore(DateOnly x, int? y, IList<int?> items) : this(x.ToString("O"), y, items) { }

    public int Total => Items.Count;

    public int Count => Items.Count(i => i.HasValue);
}