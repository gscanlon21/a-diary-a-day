
namespace Core.Models.User;

public interface IScore
{
    public List<int?> Items { get; }
    public int? ProratedScore { get; }
    public double? AverageScore { get; }
}

public interface ITag
{
    public List<ICustom> Items { get; }
}

public interface ICustom
{
    public string Name { get; init; }
}