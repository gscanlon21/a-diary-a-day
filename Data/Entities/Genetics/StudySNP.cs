using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;

/// <summary>
/// Pre-requisite exercises for other exercises
/// </summary>
[Table("study_snp")]
[DebuggerDisplay("{Exercise} needs {PrerequisiteExercise}")]
public class StudySNP
{
    // Not private so json can bind to it.
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int Order { get; init; }

    public string Notes { get; init; } = null!;

    [Display(Name = "Study")]
    public virtual int StudyId { get; init; }

    [Display(Name = "Gene")]
    public virtual int? GeneId { get; init; }
    
    [Display(Name = "SNP")]
    public virtual int? SNPId { get; init; }

    [Display(Name = "Effect Allele")]
    public string EffectAllele { get; init; } = null!;


    [InverseProperty(nameof(Genetics.Study.StudySNPs))]
    public virtual Study Study { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Genetics.SNP.StudySNPs))]
    public virtual SNP? SNP { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Genetics.Gene.StudySNPs))]
    public virtual Gene? Gene { get; private init; }


    /// <summary>
    /// Used in the edit form: whether the form field is hidden or not.
    /// </summary>
    [NotMapped]
    public bool Hide { get; set; }
}
