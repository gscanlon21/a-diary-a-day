namespace Web.ViewModels;

public abstract class ChartViewModel
{
    public bool AutoUpload { get; init; }

    public required string Token { get; init; }

    public required Component Type { get; init; }

    public string Id { get; } = $"S{Guid.NewGuid():N}";

    public required Data.Entities.Users.User User { get; init; }
}
