using Web.ViewModels;

namespace Web.Views.Shared;


public class ScoreChartViewModel
{
    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Core.Models.User.Components Type { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required IList<XScore> Scores { get; set; } = null!;

    public IList<XYScore> AverageScores => Scores.Select(s => new XYScore(s.X, s.AverageScore, s.Y?.Items ?? new List<int?>())).ToList();
    public IList<XYScore> ProratedScores => Scores.Select(s => new XYScore(s.X, s.ProratedScore, s.Y?.Items ?? new List<int?>())).ToList();
}
