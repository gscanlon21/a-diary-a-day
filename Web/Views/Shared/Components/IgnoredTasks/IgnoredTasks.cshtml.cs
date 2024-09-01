using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.IgnoredTasks;

public class IgnoredTasksViewModel
{
    [Display(Name = "Ignored Tasks")]
    public required IList<NewsletterTaskDto> Tasks { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Notes;
}
