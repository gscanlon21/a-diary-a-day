using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Views.Shared.Components.UpsertRecipe;

public class UpsertRecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UpsertRecipeModel Recipe { get; set; } = null!;
}

public class UpsertRecipeModel
{
    public int Id { get; init; }

    public int? UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public Section Section { get; set; }

    public string? Image { get; set; } = null;

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; set; } = null;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UpsertRecipeModel other
        && other.Id == Id;

    [NotMapped]
    public Section[]? SectionBinder
    {
        get => Enum.GetValues<Section>().Where(e => Section.HasFlag(e)).ToArray();
        set => Section = value?.Aggregate(Section.None, (a, e) => a | e) ?? Section.None;
    }

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
