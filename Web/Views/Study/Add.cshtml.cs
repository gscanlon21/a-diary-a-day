using Core.Models.Newsletter;
using Data.Entities.Genetics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web.Views.Study;

public class AddViewModel : IValidatableObject
{
    [ValidateNever]
    public Data.Entities.Users.User User { get; init; } = null!;
    public string Token { get; init; } = null!;

    public Section Section { get; init; }
    public int SupplementId { get; init; }
    public string Name { get; init; } = null!;
    public string Source { get; init; } = null!;

    [JsonInclude, ValidateNever]
    public IList<StudySNP> SNPs { get; set; } = [];

    [JsonInclude, ValidateNever]
    public IList<SelectListItem> GeneSelectList { get; set; } = [];

    [JsonInclude, ValidateNever]
    public IList<SelectListItem> SNPSelectList { get; set; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        foreach (var recipeIngredient in SNPs.Where(ri => !ri.Hide))
        {
            if (false && recipeIngredient.SNPId.HasValue && recipeIngredient.SNPId.HasValue)
            {
                yield return new ValidationResult($"Both the Ingredient and the Recipe cannot have values.", [nameof(SNPs)]);
            }

            if (false && !recipeIngredient.SNPId.HasValue && !recipeIngredient.SNPId.HasValue)
            {
                yield return new ValidationResult($"Either the Ingredient or the Recipe must have a value.", [nameof(SNPs)]);
            }
        }
    }
}
