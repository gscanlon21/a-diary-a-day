using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Supplements;


public class SupplementsViewModel
{
    private readonly bool _formOpen;

    public IList<NewsletterTaskDto> Supplements { get; set; } = null!;

    [Display(Name = "Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    [ValidateNever]
    public Verbosity Verbosity => Verbosity.Debug;

    [ValidateNever]
    public bool FormOpen
    {
        get => _formOpen || Supplements?.Any() != true;
        // Needs to be settable for the 'Clear' btn.
        init => _formOpen = value;
    }

    [ValidateNever]
    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue;
}
