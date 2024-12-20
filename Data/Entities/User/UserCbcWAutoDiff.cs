﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// https://www.psychiatry.org/getmedia/3345c156-1aac-4e29-ac61-1c6541cb39be/APA-DSM5TR-SeverityMeasureForAgoraphobiaAdult.pdf
/// </summary>
[Table("user_cbc_w_auto_diff")]
public class UserCbcWAutoDiff
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
    [Display(Name = "WBC")]
    public int? WBC { get; set; }

    [Range(40, 240)]
    [Display(Name = "RBC Count")]
    public int? RBCCount { get; set; }

    [Range(40, 240)]
    [Display(Name = "Hemoglobin")]
    public int? Hemoglobin { get; set; }

    [Range(40, 240)]
    [Display(Name = "Hematocrit")]
    public int? Hematocrit { get; set; }

    [Range(40, 240)]
    [Display(Name = "MCV")]
    public int? MCV { get; set; }

    [Range(40, 240)]
    [Display(Name = "MCH")]
    public int? MCH { get; set; }

    [Range(40, 240)]
    [Display(Name = "MCHC")]
    public int? MCHC { get; set; }

    [Range(40, 240)]
    [Display(Name = "RDW-CV")]
    public int? RDW_CV { get; set; }

    [Range(Consts.PlatletCountMin, Consts.PlatletCountMax)]
    [Display(Name = "PlatletCount")]
    public int? PlatletCount { get; set; }

    [Range(40, 240)]
    [Display(Name = "MPV")]
    public int? MPV { get; set; }

    [Range(40, 240)]
    [Display(Name = "Monocyte %")]
    public int? MonocytePercent { get; set; }

    [Range(40, 240)]
    [Display(Name = "Eosinophi %l")]
    public int? EosinophilPercent { get; set; }

    [Range(40, 240)]
    [Display(Name = "Basophil %")]
    public int? BasophilPercent { get; set; }

    [Range(40, 240)]
    [Display(Name = "Immature Granulocytes %")]
    public int? ImmatureGranulocytesPercent { get; set; }

    [Range(40, 240)]
    [Display(Name = "Neutrophil Absolute")]
    public int? NeutrophilAbsolute { get; set; }

    [Range(40, 240)]
    [Display(Name = "Lymphocyte Absolute")]
    public int? LymphocyteAbsolute { get; set; }

    [Range(40, 240)]
    [Display(Name = "Monocyte Absolute")]
    public int? MonocyteAbsolute { get; set; }

    [Range(40, 240)]
    [Display(Name = "Eosinophil Absolute")]
    public int? EosinophilAbsolute { get; set; }

    [Range(40, 240)]
    [Display(Name = "Basophil Absolute")]
    public int? BasophilAbsolute { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(WBC), WBC },
        { nameof(RBCCount), RBCCount },
        { nameof(Hemoglobin), Hemoglobin },
        { nameof(Hematocrit), Hematocrit },
        { nameof(MCV), MCV },
        { nameof(MCH), MCH },
        { nameof(MCHC), MCHC },
        { nameof(RDW_CV), RDW_CV },
        { nameof(PlatletCount), PlatletCount },
        { nameof(MPV), MPV },
        { nameof(MonocytePercent), MonocytePercent },
        { nameof(EosinophilPercent), EosinophilPercent },
        { nameof(BasophilPercent), BasophilPercent },
        { nameof(ImmatureGranulocytesPercent), ImmatureGranulocytesPercent },
        { nameof(NeutrophilAbsolute), NeutrophilAbsolute },
        { nameof(LymphocyteAbsolute), LymphocyteAbsolute },
        { nameof(MonocyteAbsolute), MonocyteAbsolute },
        { nameof(EosinophilAbsolute), EosinophilAbsolute },
        { nameof(BasophilAbsolute), BasophilAbsolute },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserCbcWAutoDiffs))]
    public virtual User User { get; set; } = null!;
}
