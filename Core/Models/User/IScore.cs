
namespace Core.Models.User;

public interface IScore
{
    public List<int?> Items { get; }
    public int? ProratedScore { get; }
    public int? AverageScore { get; }
}
