namespace Core.Dtos.Newsletter;

public class UserDiaryDto
{
    public int Id { get; init; }

    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    public DateOnly Date { get; init; }

    /// <summary>
    /// Title to display for the list item in the app.
    /// </summary>
    public string Title() => Date.ToLongDateString();

    /// <summary>
    /// Description to display for the list item in the app.
    /// </summary>
    public string Description() => $"{Date}";
}
