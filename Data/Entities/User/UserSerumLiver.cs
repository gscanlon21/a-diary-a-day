using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_liver")]
public class UserSerumLiver
{
    public class Consts
    {
        public const double ALTMin = 0;
        public const double ALTMax = 1000;
        public const double ALTStep = .1;

        public const double AlbuminMin = 0;
        public const double AlbuminMax = 1000;
        public const double AlbuminStep = .1;

        public const double AlbuminGlobulinMin = 0;
        public const double AlbuminGlobulinMax = 1000;
        public const double AlbuminGlobulinStep = .1;

        public const double ALPMin = 0;
        public const double ALPMax = 1000;
        public const double ALPStep = .1;

        public const double ASTMin = 0;
        public const double ASTMax = 1000;
        public const double ASTStep = .1;

        public const double GGTMin = 0;
        public const double GGTMax = 1000;
        public const double GGTStep = .1;

        public const double GlobulinMin = 0;
        public const double GlobulinMax = 1000;
        public const double GlobulinStep = .1;

        public const double BilirubinMin = 0;
        public const double BilirubinMax = 1000;
        public const double BilirubinStep = .1;

        public const double ProteinMin = 0;
        public const double ProteinMax = 1000;
        public const double ProteinStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.ALTMin, Consts.ALTMax)]
    [Display(Name = "ALT")]
    public double? ALT { get; set; }

    [Range(Consts.AlbuminMin, Consts.AlbuminMax)]
    [Display(Name = "Albumin")]
    public double? Albumin { get; set; }

    [Range(Consts.AlbuminGlobulinMin, Consts.AlbuminGlobulinMax)]
    [Display(Name = "Albumin / Globulin Ratio")]
    public double? AlbuminGlobulin { get; set; }

    [Range(Consts.ALPMin, Consts.ALPMax)]
    [Display(Name = "ALP")]
    public double? ALP { get; set; }

    [Range(Consts.ASTMin, Consts.ASTMax)]
    [Display(Name = "AST")]
    public double? AST { get; set; }

    [Range(Consts.GGTMin, Consts.GGTMax)]
    [Display(Name = "GGT")]
    public double? GGT { get; set; }

    [Range(Consts.GlobulinMin, Consts.GlobulinMax)]
    [Display(Name = "Globulin")]
    public double? Globulin { get; set; }

    [Range(Consts.BilirubinMin, Consts.BilirubinMax)]
    [Display(Name = "Bilirubin")]
    public double? Bilirubin { get; set; }

    [Range(Consts.ProteinMin, Consts.ProteinMax)]
    [Display(Name = "Protein")]
    public double? Protein { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(ALT), ALT },
        { nameof(Albumin), Albumin },
        { nameof(AlbuminGlobulin), AlbuminGlobulin },
        { nameof(ALP), ALP },
        { nameof(AST), AST },
        { nameof(GGT), GGT },
        { nameof(Globulin), Globulin },
        { nameof(Bilirubin), Bilirubin },
        { nameof(Protein), Protein },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSerumLivers))]
    public virtual User User { get; set; } = null!;
}
