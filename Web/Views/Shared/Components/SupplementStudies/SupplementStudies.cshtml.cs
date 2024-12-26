using Data.Entities.Genetics;
using Data.Entities.Task;

namespace Web.Views.Shared.Components.SupplementStudies;

public class SupplementStudiesViewModel
{
    public required Data.Entities.User.User User { get; init; }

    public required string Token { get; init; }

    public required IList<StudySupplement> Studies { get; init; }

    public required UserTask Supplement { get; init; }
}
