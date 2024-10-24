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
        public const int BlastocystisMin = 0;
        public const int BlastocystisMax = 2;
        public const int BlastocystisStep = 1;

        public const int CampylobacterMin = 0;
        public const int CampylobacterMax = 2;
        public const int CampylobacterStep = 1;

        public const int ClostridioidesDifficileMin = 0;
        public const int ClostridioidesDifficileMax = 2;
        public const int ClostridioidesDifficileStep = 1;

        public const int CryptosporidiumMin = 0;
        public const int CryptosporidiumMax = 2;
        public const int CryptosporidiumStep = 1;

        public const int DientamoebaFragilisMin = 0;
        public const int DientamoebaFragilisMax = 2;
        public const int DientamoebaFragilisStep = 1;

        public const int EntamoebaHistolyticaMin = 0;
        public const int EntamoebaHistolyticaMax = 2;
        public const int EntamoebaHistolyticaStep = 1;

        public const int EscherichiaColiO157_H7Min = 0;
        public const int EscherichiaColiO157_H7Max = 2;
        public const int EscherichiaColiO157_H7Step = 1;

        public const int GiardiaIntestinalisMin = 0;
        public const int GiardiaIntestinalisMax = 2;
        public const int GiardiaIntestinalisStep = 1;

        public const int HelicobacterPyloriMin = 0;
        public const int HelicobacterPyloriMax = 2;
        public const int HelicobacterPyloriStep = 1;

        public const int SalmonellaEntericaMin = 0;
        public const int SalmonellaEntericaMax = 2;
        public const int SalmonellaEntericaStep = 1;

        public const int VibrioCholeraeMin = 0;
        public const int VibrioCholeraeMax = 2;
        public const int VibrioCholeraeStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 2)]
    [Display(Name = "Blastocystis")]
    public int? Blastocystis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Campylobacter")]
    public int? Campylobacter { get; set; }

    [Range(0, 2)]
    [Display(Name = "Clostridioides difficile")]
    public int? ClostridioidesDifficile { get; set; }

    [Range(0, 2)]
    [Display(Name = "Cryptosporidium")]
    public int? Cryptosporidium { get; set; }

    [Range(0, 2)]
    [Display(Name = "Dientamoeba fragilis")]
    public int? DientamoebaFragilis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Entamoeba histolytica")]
    public int? EntamoebaHistolytica { get; set; }

    [Range(0, 2)]
    [Display(Name = "Escherichia coli O157:H7")]
    public int? EscherichiaColiO157_H7 { get; set; }

    [Range(0, 2)]
    [Display(Name = "Giardia intestinalis")]
    public int? GiardiaIntestinalis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Helicobacter pylori")]
    public int? HelicobacterPylori { get; set; }

    [Range(0, 2)]
    [Display(Name = "Salmonella enterica")]
    public int? SalmonellaEnterica { get; set; }

    [Range(0, 2)]
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

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutPathogens))]
    public virtual User User { get; set; } = null!;
}
