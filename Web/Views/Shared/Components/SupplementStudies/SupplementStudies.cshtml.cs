using Core.Models.Newsletter;
using Data.Entities.Genetics;
using Data.Entities.Task;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Views.Shared.Components.SupplementStudies;

public class SupplementStudiesViewModel
{
    public required Data.Entities.Users.User User { get; init; }
    public required Section Section { get; init; }
    public required string Token { get; init; }

    public required IList<SelectListItem> Studies { get; init; }

    public required IList<StudySupplement> StudySupplements { get; init; }

    public required UserTask Supplement { get; init; }

    public int StudyId { get; init; }
}
