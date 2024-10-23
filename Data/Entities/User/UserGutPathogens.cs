using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_pathogens"), Comment("User variation weight log")]
public class UserGutPathogens
{
    public class Consts
    {
        public const int PlatletCountMin = 100;
        public const int PlatletCountMax = 500;
        public const int PlatletCountStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(40, 240)]
    [Display(Name = "Blastocystis")]
    public int? Blastocystis { get; set; }

    [Range(40, 240)]
    [Display(Name = "Campylobacter")]
    public int? Campylobacter { get; set; }

    [Range(40, 240)]
    [Display(Name = "Clostridioides difficile")]
    public int? ClostridioidesDifficile { get; set; }

    [Range(40, 240)]
    [Display(Name = "Cryptosporidium")]
    public int? Cryptosporidium { get; set; }

    [Range(40, 240)]
    [Display(Name = "Dientamoeba fragilis")]
    public int? DientamoebaFragilis { get; set; }

    [Range(40, 240)]
    [Display(Name = "Entamoeba histolytica")]
    public int? EntamoebaHistolytica { get; set; }

    [Range(40, 240)]
    [Display(Name = "Escherichia coli O157:H7")]
    public int? EscherichiaColiO157_H7 { get; set; }

    [Range(40, 240)]
    [Display(Name = "Giardia intestinalis")]
    public int? GiardiaIntestinalis { get; set; }

    [Range(Consts.PlatletCountMin, Consts.PlatletCountMax)]
    [Display(Name = "Helicobacter pylori")]
    public int? HelicobacterPylori { get; set; }

    [Range(40, 240)]
    [Display(Name = "Salmonella enterica")]
    public int? SalmonellaEnterica { get; set; }

    [Range(40, 240)]
    [Display(Name = "Vibrio cholerae")]
    public int? VibrioCholerae { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(Blastocystis), Blastocystis },
        { nameof(Campylobacter), Campylobacter },
        { nameof(ClostridioidesDifficile), ClostridioidesDifficile },
        { nameof(Cryptosporidium), Cryptosporidium },
        { nameof(DientamoebaFragilis), DientamoebaFragilis },
        { nameof(EntamoebaHistolytica), EntamoebaHistolytica },
        { nameof(EscherichiaColiO157_H7), EscherichiaColiO157_H7 },
        { nameof(GiardiaIntestinalis), GiardiaIntestinalis },
        { nameof(HelicobacterPylori), HelicobacterPylori },
        { nameof(SalmonellaEnterica), SalmonellaEnterica },
        { nameof(VibrioCholerae), VibrioCholerae },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserCbcWAutoDiffs))]
    public virtual User User { get; set; } = null!;
}
