using Web.ViewModels;

namespace Web.Views.Shared;


public class ScoreChartViewModel : ChartViewModel
{
    public required IList<XScore> Scores { get; set; } = null!;

    public IList<XYScore> AverageScores => Scores.Select(s => new XYScore(s.X, s.AverageScore, s.Y?.Items ?? new List<int?>())).ToList();
    public IList<XYScore> ProratedScores => Scores.Select(s => new XYScore(s.X, s.ProratedScore, s.Y?.Items ?? new List<int?>())).ToList();
}
