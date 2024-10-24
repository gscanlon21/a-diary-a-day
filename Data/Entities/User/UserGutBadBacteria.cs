using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_bad_bacteria"), Comment("User variation weight log")]
public class UserGutBadBacteria
{
    public class Consts
    {
        public const double BlautiaMin = 0;
        public const double BlautiaMax = 100;
        public const double BlautiaStep = .1;

        public const double CitrobacterFreundiiMin = 0;
        public const double CitrobacterFreundiiMax = 100;
        public const double CitrobacterFreundiiStep = .1;

        public const double ClostridioidesDifficileMin = 0;
        public const double ClostridioidesDifficileMax = 100;
        public const double ClostridioidesDifficileStep = .1;

        public const double EggerthellaMin = 0;
        public const double EggerthellaMax = 100;
        public const double EggerthellaStep = .1;

        public const double EggerthellaLentaMin = 0;
        public const double EggerthellaLentaMax = 100;
        public const double EggerthellaLentaStep = .1;

        public const double EnterobacteriaceaeMin = 0;
        public const double EnterobacteriaceaeMax = 100;
        public const double EnterobacteriaceaeStep = .1;

        public const double EnterobacteriaceaeAndPseudomonasMin = 0;
        public const double EnterobacteriaceaeAndPseudomonasMax = 100;
        public const double EnterobacteriaceaeAndPseudomonasStep = .1;

        public const double EnterococcusMin = 0;
        public const double EnterococcusMax = 100;
        public const double EnterococcusStep = .1;

        public const double EnterococcusFaecalisMin = 0;
        public const double EnterococcusFaecalisMax = 100;
        public const double EnterococcusFaecalisStep = .1;

        public const double EnterococcusFaeciumMin = 0;
        public const double EnterococcusFaeciumMax = 100;
        public const double EnterococcusFaeciumStep = .1;

        public const double EnterococcusFaecalisAndFaeciumMin = 0;
        public const double EnterococcusFaecalisAndFaeciumMax = 100;
        public const double EnterococcusFaecalisAndFaeciumStep = .1;

        public const double EscherichiaMin = 0;
        public const double EscherichiaMax = 100;
        public const double EscherichiaStep = .1;

        public const double EscherichiaColiMin = 0;
        public const double EscherichiaColiMax = 100;
        public const double EscherichiaColiStep = .1;

        public const double KlebsiellaMin = 0;
        public const double KlebsiellaMax = 100;
        public const double KlebsiellaStep = .1;

        public const double RuminococcusGnavusMin = 0;
        public const double RuminococcusGnavusMax = 100;
        public const double RuminococcusGnavusStep = .1;

        public const double RuminococcusTorquesMin = 0;
        public const double RuminococcusTorquesMax = 100;
        public const double RuminococcusTorquesStep = .1;

        public const double StaphylococcusMin = 0;
        public const double StaphylococcusMax = 100;
        public const double StaphylococcusStep = .1;

        public const double StaphylococcusAureusMin = 0;
        public const double StaphylococcusAureusMax = 100;
        public const double StaphylococcusAureusStep = .1;

        public const double StreptococcusMinusThermophilusAndSalivariusMin = 0;
        public const double StreptococcusMinusThermophilusAndSalivariusMax = 100;
        public const double StreptococcusMinusThermophilusAndSalivariusStep = .1;

        public const double VeillonellaMin = 0;
        public const double VeillonellaMax = 100;
        public const double VeillonellaStep = .1;

        public const double YersiniaEnterocoliticaMin = 0;
        public const double YersiniaEnterocoliticaMax = 100;
        public const double YersiniaEnterocoliticaStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 100)]
    [Display(Name = "Blautia")]
    public double? Blautia { get; set; }

    [Range(0, 100)]
    [Display(Name = "Citrobacter freundii")]
    public double? CitrobacterFreundii { get; set; }

    [Range(0, 100)]
    [Display(Name = "Clostridioides difficile")]
    public double? ClostridioidesDifficile { get; set; }

    [Range(0, 100)]
    [Display(Name = "Eggerthella")]
    public double? Eggerthella { get; set; }

    [Range(0, 100)]
    [Display(Name = "Eggerthella lenta")]
    public double? EggerthellaLenta { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterobacteriaceae")]
    public double? Enterobacteriaceae { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterobacteriaceae + Pseudomonas")]
    public double? EnterobacteriaceaeAndPseudomonas { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterococcus")]
    public double? Enterococcus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterococcus faecalis")]
    public double? EnterococcusFaecalis { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterococcus faecium")]
    public double? EnterococcusFaecium { get; set; }

    [Range(0, 100)]
    [Display(Name = "Enterococcus faecalis + faecium")]
    public double? EnterococcusFaecalisAndFaecium { get; set; }

    [Range(0, 100)]
    [Display(Name = "Escherichia")]
    public double? Escherichia { get; set; }

    [Range(0, 100)]
    [Display(Name = "Escherichia coli")]
    public double? EscherichiaColi { get; set; }

    [Range(0, 100)]
    [Display(Name = "Klebsiella")]
    public double? Klebsiella { get; set; }

    [Range(0, 100)]
    [Display(Name = "Ruminococcus gnavus")]
    public double? RuminococcusGnavus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Ruminococcus torques")]
    public double? RuminococcusTorques { get; set; }

    [Range(0, 100)]
    [Display(Name = "Staphylococcus")]
    public double? Staphylococcus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Staphylococcus aureus")]
    public double? StaphylococcusAureus { get; set; }

    [Range(0, 100)]
    [Display(Name = "Streptococcus (- thermophilus and salivarius)")]
    public double? StreptococcusMinusThermophilusAndSalivarius { get; set; }

    [Range(0, 100)]
    [Display(Name = "Veillonella")]
    public double? Veillonella { get; set; }

    [Range(0, 100)]
    [Display(Name = "Yersinia enterocolitica")]
    public double? YersiniaEnterocolitica { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(Blautia), Blautia },
        { nameof(CitrobacterFreundii), CitrobacterFreundii },
        { nameof(ClostridioidesDifficile), ClostridioidesDifficile },
        { nameof(Eggerthella), Eggerthella },
        { nameof(EggerthellaLenta), EggerthellaLenta },
        { nameof(Enterobacteriaceae), Enterobacteriaceae },
        { nameof(EnterobacteriaceaeAndPseudomonas), EnterobacteriaceaeAndPseudomonas },
        { nameof(Enterococcus), Enterococcus },
        { nameof(EnterococcusFaecalis), EnterococcusFaecalis },
        { nameof(EnterococcusFaecium), EnterococcusFaecium },
        { nameof(EnterococcusFaecalisAndFaecium), EnterococcusFaecalisAndFaecium },
        { nameof(Escherichia), Escherichia },
        { nameof(EscherichiaColi), EscherichiaColi },
        { nameof(Klebsiella), Klebsiella },
        { nameof(RuminococcusGnavus), RuminococcusGnavus },
        { nameof(RuminococcusTorques), RuminococcusTorques },
        { nameof(Staphylococcus), Staphylococcus },
        { nameof(StaphylococcusAureus), StaphylococcusAureus },
        { nameof(StreptococcusMinusThermophilusAndSalivarius), StreptococcusMinusThermophilusAndSalivarius },
        { nameof(Veillonella), Veillonella },
        { nameof(YersiniaEnterocolitica), YersiniaEnterocolitica },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutBadBacteria))]
    public virtual User User { get; set; } = null!;
}
