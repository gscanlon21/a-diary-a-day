using Data.Entities.User;

namespace Web.ViewModels.User.Components;

public class DepressionViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserDepression UserDepression { get; init; } = null!;
}
