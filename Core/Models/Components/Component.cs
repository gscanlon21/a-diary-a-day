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

    [Display(Name = "Tasks", Order = 0)]
    Tasks = 1 << 0, // 1

    [Display(Name = "Mood Tracking", Order = 1)]
    Mood = 1 << 1, // 2

    [Display(Name = "Sleep Tracking", Order = 2)]
    Sleep = 1 << 2, // 4

    [Display(Name = "People Tracking", Order = 3)]
    People = 1 << 3, // 8

    [Display(Name = "Symptom Tracking", Order = 4)]
    Symptom = 1 << 4, // 16

    [Display(Name = "Emotion Tracking", Order = 5)]
    Emotion = 1 << 5, // 32

    [Display(Name = "Activity Tracking", Order = 6)]
    Activity = 1 << 6, // 64

    [Display(Name = "Medicine Tracking", Order = 7)]
    Medicine = 1 << 7, // 128

    [Display(Name = "Acute Stress Severity Tracking", Order = 8)]
    AcuteStressSeverity = 1 << 8, // 256

    [Display(Name = "Agoraphobia Severity Tracking", Order = 9)]
    AgoraphobiaSeverity = 1 << 9, // 512

    [Display(Name = "Depression Severity Tracking", Order = 10)]
    DepressionSeverity = 1 << 10, // 1024

    [Display(Name = "Dissociative Severity Tracking", Order = 11)]
    DissociativeSeverity = 1 << 11, // 2048

    [Display(Name = "Generalized Anxiety Severity", Order = 12)]
    GeneralizedAnxietySeverity = 1 << 12, // 4096

    [Display(Name = "Panic Disorder Severity", Order = 13)]
    PanicSeverity = 1 << 13, // 8192

    [Display(Name = "PTSD Severity", Order = 14)]
    PTSDSeverity = 1 << 14, // 16384

    [Display(Name = "Social Anxiety Severity", Order = 15)]
    SocialAnxietySeverity = 1 << 15, // 32768

    [Display(Name = "Journal", Order = 99)]
    Journal = 1 << 16, // 65536

    [Display(Name = "Complete Metabolic Panel", Order = 21), SubComponent<CompleteMetabolicPanel>()]
    CompleteMetabolicPanel = 1 << 17, // 131072

    [Display(Name = "Dry Eyes", Order = 90)]
    DryEyes = 1 << 18, // 262144

    [Display(Name = "Feast Allergens", Order = 95)]
    FeastAllergens = 1 << 19, // 524288

    [Display(Name = "Cbc W Auto Differential", Order = 22), SubComponent<CbcWAutoDiff>()]
    CbcWAutoDiff = 1 << 20, // 1048576

    [Display(Name = "Blood Work", Order = 23), SubComponent<BloodWork>()]
    BloodWork = 1 << 21, // 2097152

    [Display(Name = "Depression", Order = 16)]
    Depression = 1 << 22, // 4194304

    [Display(Name = "Gut Pillars", Order = 30)]
    GutPillars = 1 << 23, // 8388608

    [Display(Name = "Gut Fungi", Order = 31)]
    GutFungi = 1 << 24, // 16777216

    [Display(Name = "Gut Pathogens", Order = 32)]
    GutPathogens = 1 << 25, // 33554432

    [Display(Name = "Gut Good Bacteria", Order = 33)]
    GutGoodBacteria = 1 << 26, // 67108864

    [Display(Name = "Gut Bad Bacteria", Order = 34)]
    GutBadBacteria = 1 << 27, // 134217728

    [Display(Name = "Gut Conditional Bacteria", Order = 35)]
    GutConditionalBacteria = 1 << 28, // 268435456

    [Display(Name = "Gut Micronutrients", Order = 36)]
    GutMicronutrients = 1 << 29, // 536870912

    [Display(Name = "Gut Short Chain Fatty Acids", Order = 37)]
    GutShortChainFattyAcids = 1L << 30, // 1073741824

    [Display(Name = "Gut Probiotics", Order = 38)]
    GutProbiotics = 1L << 31, // 2147483648

    [Display(Name = "Blood Pressure", Order = 20)]
    BloodPressure = 1L << 32, // 4294967296

    [Display(Name = "Urine", Order = 20)]
    Urine = 1L << 33, // 8589934592

    [Display(Name = "Serum Autoimmunity", Order = 20)]
    SerumAutoimmunity = 1L << 34, // 17179869184

    [Display(Name = "Serum Blood", Order = 20)]
    SerumBlood = 1L << 35, //  34359738368

    [Display(Name = "Serum Electrolytes", Order = 20)]
    SerumElectrolytes = 1L << 36, // 68719476736

    [Display(Name = "Serum Heart", Order = 20)]
    SerumHeart = 1L << 37, // 137438953472

    [Display(Name = "Serum Heavy Metals", Order = 20)]
    SerumHeavyMetals = 1L << 38, // 274877906944

    [Display(Name = "Serum Immune Regulation", Order = 20)]
    SerumImmuneRegulation = 1L << 39, // 549755813888

    [Display(Name = "Serum Kidney", Order = 20)]
    SerumKidney = 1L << 40, // 1099511627776

    [Display(Name = "Serum Liver", Order = 20)]
    SerumLiver = 1L << 41, // 2199023255552

    [Display(Name = "Serum Male Health", Order = 20)]
    SerumMaleHealth = 1L << 42, // 4398046511104

    [Display(Name = "Serum Female Health", Order = 20)]
    SerumFemaleHealth = 1L << 43, // 8796093022208

    [Display(Name = "Serum Metabolic", Order = 20)]
    SerumMetabolic = 1L << 44, // 17592186044416

    [Display(Name = "Serum Nutrients", Order = 20)]
    SerumNutrients = 1L << 45, // 35184372088832

    [Display(Name = "Serum Pancreas", Order = 20)]
    SerumPancreas = 1L << 46, // 70368744177664

    [Display(Name = "Serum Stress", Order = 20)]
    SerumStress = 1L << 47, // 140737488355328

    [Display(Name = "Serum Thyroid", Order = 20)]
    SerumThyroid = 1L << 48, // 281474976710656


    All = Mood | Sleep | People | Symptom | Emotion | Activity | Medicine | BloodPressure
        | AcuteStressSeverity | AgoraphobiaSeverity | DepressionSeverity | DissociativeSeverity
        | GeneralizedAnxietySeverity | PanicSeverity | PTSDSeverity | SocialAnxietySeverity
        | Journal | CompleteMetabolicPanel | Tasks | DryEyes | FeastAllergens | CbcWAutoDiff
        | BloodWork | Depression | GutPillars | GutFungi | GutPathogens
        | GutGoodBacteria | GutBadBacteria | GutConditionalBacteria
        | GutShortChainFattyAcids | GutMicronutrients | GutProbiotics
        | Urine | SerumAutoimmunity | SerumBlood | SerumElectrolytes
        | SerumHeart | SerumHeavyMetals | SerumImmuneRegulation | SerumKidney
        | SerumLiver | SerumMaleHealth | SerumFemaleHealth | SerumMetabolic
        | SerumNutrients | SerumPancreas | SerumStress | SerumThyroid
}
