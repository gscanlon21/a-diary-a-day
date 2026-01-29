using Core.Models.User;
using Data.Entities.Users;

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
public record XyGroup(IGroup Group, string X, double? Y, object? Extra)
{
    public XyGroup(IGroup group, string x, double? y) : this(group, x, y, null) { }
    public XyGroup(IGroup group, DateOnly x, double? y) : this(group, x.ToString("O"), y) { }
    public XyGroup(IGroup group, DateOnly x, double? y, object? extra) : this(group, x.ToString("O"), y, extra) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XCustom(string X, UserCustomGroup? Y, UserCustom Label)
{
    public XCustom(DateOnly x, UserCustomGroup? y, UserCustom label) : this(x.ToString("O"), y, label) { }
}

/// <summary>
/// For chart.js
/// </summary>
public record XScore(string X, IScore? Y, double? ProratedScore, double? AverageScore)
{
    public XScore(DateOnly x, IScore? y) : this(x.ToString("O"), y, y?.ProratedScore, y?.AverageScore) { }
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

public sealed record UserCustomGroup(DateOnly Date, string Name) : IGroup
{
    public double Value { get; init; } = 1;
    public string? Description { get; init; }
    public int Order { get; } = 1;

    public override int GetHashCode() => HashCode.Combine(Name);
    public bool Equals(UserCustomGroup? other) => other?.Name == Name;
};