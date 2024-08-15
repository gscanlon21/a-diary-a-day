using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
public class NewsletterEntityDto
{
    public int Id { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    [Required]
    public DateOnly Date { get; init; }
}
