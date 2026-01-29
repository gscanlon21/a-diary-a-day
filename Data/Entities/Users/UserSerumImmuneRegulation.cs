using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_serum_immune_regulation")]
public class UserSerumImmuneRegulation
{
    public class Consts
    {
        public const double BasophilisMin = 0;
        public const double BasophilisMax = 10000;
        public const double BasophilisStep = .1;

        public const double EosinophilisMin = 0;
        public const double EosinophilisMax = 10000;
        public const double EosinophilisStep = .1;

        public const double LymphocytesMin = 0;
        public const double LymphocytesMax = 10000;
        public const double LymphocytesStep = .1;

        public const double MonocytesMin = 0;
        public const double MonocytesMax = 10000;
        public const double MonocytesStep = .1;

        public const double NeutrophilisMin = 0;
        public const double NeutrophilisMax = 10000;
        public const double NeutrophilisStep = .1;

        public const double BasophilisPercentMin = 0;
        public const double BasophilisPercentMax = 1000;
        public const double BasophilisPercentStep = .1;

        public const double EosinophilisPercentMin = 0;
        public const double EosinophilisPercentMax = 1000;
        public const double EosinophilisPercentStep = .1;

        public const double LymphocytesPercentMin = 0;
        public const double LymphocytesPercentMax = 1000;
        public const double LymphocytesPercentStep = .1;

        public const double MonocytesPercentMin = 0;
        public const double MonocytesPercentMax = 1000;
        public const double MonocytesPercentStep = .1;

        public const double NeutrophilisPercentMin = 0;
        public const double NeutrophilisPercentMax = 1000;
        public const double NeutrophilisPercentStep = .1;

        public const double HsCRPMin = 0;
        public const double HsCRPMax = 1000;
        public const double HsCRPStep = .1;

        public const double WBCCountMin = 0;
        public const double WBCCountMax = 1000;
        public const double WBCCountStep = .1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(Consts.BasophilisPercentMin, Consts.BasophilisPercentMax)]
    [Display(Name = "Basophilis %")]
    public double? BasophilisPercent { get; set; }

    [Range(Consts.EosinophilisPercentMin, Consts.EosinophilisPercentMax)]
    [Display(Name = "Eosinophilis %")]
    public double? EosinophilisPercent { get; set; }

    [Range(Consts.LymphocytesPercentMin, Consts.LymphocytesPercentMax)]
    [Display(Name = "Lymphocytes %")]
    public double? LymphocytesPercent { get; set; }

    [Range(Consts.MonocytesPercentMin, Consts.MonocytesPercentMax)]
    [Display(Name = "Monocytes %")]
    public double? MonocytesPercent { get; set; }

    [Range(Consts.NeutrophilisPercentMin, Consts.NeutrophilisPercentMax)]
    [Display(Name = "Neutrophilis %")]
    public double? NeutrophilisPercent { get; set; }

    [Range(Consts.BasophilisMin, Consts.BasophilisMax)]
    [Display(Name = "Basophilis")]
    public double? Basophilis { get; set; }

    [Range(Consts.EosinophilisMin, Consts.EosinophilisMax)]
    [Display(Name = "Eosinophilis")]
    public double? Eosinophilis { get; set; }

    [Range(Consts.LymphocytesMin, Consts.LymphocytesMax)]
    [Display(Name = "Lymphocytes")]
    public double? Lymphocytes { get; set; }

    [Range(Consts.MonocytesMin, Consts.MonocytesMax)]
    [Display(Name = "Monocytes")]
    public double? Monocytes { get; set; }

    [Range(Consts.NeutrophilisMin, Consts.NeutrophilisMax)]
    [Display(Name = "Neutrophilis")]
    public double? Neutrophilis { get; set; }

    [Range(Consts.HsCRPMin, Consts.HsCRPMax)]
    [Display(Name = "hs-CRP")]
    public double? HsCRP { get; set; }

    [Range(Consts.WBCCountMin, Consts.WBCCountMax)]
    [Display(Name = "WBC Count")]
    public double? WBCCount { get; set; }

    [NotMapped]
    public Dictionary<string, double?> Items => new()
    {
        { nameof(EosinophilisPercent), EosinophilisPercent },
        { nameof(Eosinophilis), Eosinophilis },
        { nameof(LymphocytesPercent), LymphocytesPercent },
        { nameof(Lymphocytes), Lymphocytes },
        { nameof(MonocytesPercent), MonocytesPercent },
        { nameof(Monocytes), Monocytes },
        { nameof(BasophilisPercent), BasophilisPercent },
        { nameof(Basophilis), Basophilis },
        { nameof(NeutrophilisPercent), NeutrophilisPercent },
        { nameof(Neutrophilis), Neutrophilis },
        { nameof(HsCRP), HsCRP },
        { nameof(WBCCount), WBCCount },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.Users.User.UserSerumImmuneRegulations))]
    public virtual User User { get; set; } = null!;
}
