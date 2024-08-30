namespace Core.Models.User;

/// <summary>
/// Default implementation uses scoring for the DSM-5.
/// </summary>
public interface IScore
{
    public List<int?> Items { get; }
    public int? ProratedScore => Items.Any(d => d.HasValue) ? Convert.ToInt32(Items.Count * Items.Sum() / (double)Items.Count(d => d.HasValue)) : null;
    public double? AverageScore => Items.All(d => d.HasValue) ? Items.Sum() / (double)Items.Count : null;
}

public interface ITag
{
    public List<ICustom> Items { get; }
}

public interface ICustom
{
    public string Name { get; init; }
}