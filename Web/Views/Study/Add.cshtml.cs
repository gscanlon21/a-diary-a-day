using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web.Views.Study;

public class AddViewModel
{
    [ValidateNever]
    public Data.Entities.User.User User { get; init; } = null!;
    public string Token { get; init; } = null!;

    public int SupplementId { get; init; }
    public string Name { get; init; } = null!;
    public string Source { get; init; } = null!;
}
