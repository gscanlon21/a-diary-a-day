namespace Web.ViewModels;

/// <summary>
/// For chart.js
/// </summary>
public record Xy(string X, int? Y)
{
    public Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
}