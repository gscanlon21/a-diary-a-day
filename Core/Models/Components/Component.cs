using Core.Attributes;
using Core.Models.Components.SubComponents;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Components;

/// <summary>
/// Controls access to user features.
/// </summary>
[Flags]
public enum Component : long
{
    None = 0,

    [Display(Name = "Allergens")]
    Allergens = 1L << 0, // 1

    [Display(Name = "Mood", Order = 1)]
    Mood = 1L << 1, // 2

    [Display(Name = "Sleep", Order = 2)]
    Sleep = 1L << 2, // 4

    [Display(Name = "People", Order = 3)]
    People = 1L << 3, // 8

    [Display(Name = "Symptoms", Order = 4)]
    Symptom = 1L << 4, // 16

    [Display(Name = "Emotions", Order = 5)]
    Emotion = 1L << 5, // 32

    [Display(Name = "Activities", Order = 6)]
    Activity = 1L << 6, // 64

    [Display(Name = "Medications", Order = 7)]
    Medicine = 1L << 7, // 128

    [Display(Name = "Blood Pressure", Order = 8)]
    BloodPressure = 1L << 8, // 256

    [Display(Name = "Dry Eyes", Order = 09)]
    DryEyes = 1L << 9, // 512

    [Display(Name = "Journal", Order = 110)]
    Journal = 1L << 10, // 1024

    [Display(Name = "Depression", Order = 11)]
    Depression = 1L << 11, // 2048

    [Display(Name = "Depression Severity", Order = 12)]
    DepressionSeverity = 1L << 12, // 4096

    [Display(Name = "Agoraphobia Severity", Order = 13)]
    AgoraphobiaSeverity = 1L << 13, // 8192

    [Display(Name = "Acute Stress Severity", Order = 14)]
    AcuteStressSeverity = 1L << 14, // 16384

    [Display(Name = "Dissociative Severity", Order = 15)]
    DissociativeSeverity = 1L << 15, // 32768

    [Display(Name = "Panic Disorder Severity", Order = 16)]
    PanicSeverity = 1L << 16, // 65536

    [Display(Name = "Social Anxiety Severity", Order = 17)]
    SocialAnxietySeverity = 1L << 17, // 131072

    [Display(Name = "Generalized Anxiety Severity", Order = 18)]
    GeneralizedAnxietySeverity = 1L << 18, // 262144

    [Display(Name = "Post-Traumatic Stress Severity", Order = 19)]
    PTSDSeverity = 1L << 19, // 524288

    [Display(Name = "Urine", Order = 20)]
    Urine = 1L << 20, // 1048576

    [Display(Name = "Serum Stress", Order = 21)]
    SerumStress = 1L << 21, // 2097152

    [Display(Name = "Serum Autoimmunity", Order = 22)]
    SerumAutoimmunity = 1L << 22, // 4194304

    [Display(Name = "Serum Electrolytes", Order = 23)]
    SerumElectrolytes = 1L << 23, // 8388608

    [Display(Name = "Serum Heavy Metals", Order = 24)]
    SerumHeavyMetals = 1L << 24, // 16777216

    [Display(Name = "Gut Short Chain Fatty Acids", Order = 25)]
    GutShortChainFattyAcids = 1L << 25, // 33554432

    [Display(Name = "Gut Micronutrients", Order = 26)]
    GutMicronutrients = 1L << 26, // 67108864

    [Display(Name = "Gut Pillars", Order = 27)]
    GutPillars = 1L << 27, // 134217728

    [Display(Name = "Gut Fungi", Order = 28)]
    GutFungi = 1L << 28, // 268435456


    #region Disabled Components

    SerumBlood = 1L << 45, // 35184372088832
    SerumHeart = 1L << 46, // 70368744177664
    SerumLiver = 1L << 47, // 140737488355328
    SerumKidney = 1L << 48, // 281474976710656
    SerumPancreas = 1L << 49, // 562949953421312
    SerumThyroid = 1L << 50, // 1125899906842624
    SerumNutrients = 1L << 51, // 2251799813685248
    SerumMetabolic = 1L << 52, // 4503599627370496
    SerumMaleHealth = 1L << 53, // 9007199254740992
    SerumFemaleHealth = 1L << 54, // 18014398509481984
    SerumImmuneRegulation = 1L << 55, // 36028797018963968
    GutConditionalBacteria = 1L << 56, // 72057594037927936
    GutProbiotics = 1L << 57, // 144115188075855872
    GutGoodBacteria = 1L << 58, // 288230376151711744
    GutBadBacteria = 1L << 59, // 576460752303423488
    GutPathogens = 1L << 60, // 1152921504606846976

    [SubComponent<BloodWork>()]
    BloodWork = 1L << 61, // 2305843009213693952

    [SubComponent<CbcWAutoDiff>()]
    CbcWAutoDiff = 1L << 62, // 4611686018427387904

    [SubComponent<CompleteMetabolicPanel>()]
    CompleteMetabolicPanel = 1L << 63, // 9223372036854775808

    #endregion

    All = Mood | Sleep | People | Symptom | Emotion | Activity | Medicine | BloodPressure
        | AcuteStressSeverity | AgoraphobiaSeverity | DepressionSeverity | DissociativeSeverity
        | GeneralizedAnxietySeverity | PanicSeverity | PTSDSeverity | SocialAnxietySeverity
        | Journal | CompleteMetabolicPanel | DryEyes | Allergens | CbcWAutoDiff
        | BloodWork | Depression | GutPillars | GutFungi | GutPathogens
        | GutGoodBacteria | GutBadBacteria | GutConditionalBacteria
        | GutShortChainFattyAcids | GutMicronutrients | GutProbiotics
        | Urine | SerumAutoimmunity | SerumBlood | SerumElectrolytes
        | SerumHeart | SerumHeavyMetals | SerumImmuneRegulation | SerumKidney
        | SerumLiver | SerumMaleHealth | SerumFemaleHealth | SerumMetabolic
        | SerumNutrients | SerumPancreas | SerumStress | SerumThyroid
}
