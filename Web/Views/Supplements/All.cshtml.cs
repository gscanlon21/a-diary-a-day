using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Supplements;


public class SupplementsViewModel
{
    public SupplementsViewModel() { }

    public IList<NewsletterTaskDto> Supplements { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }


    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue;
}
