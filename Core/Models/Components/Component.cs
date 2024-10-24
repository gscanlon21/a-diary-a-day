using Core.Attributes;
using Core.Models.Components.SubComponents;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Components;

/// <summary>
/// Controls access to user features.
/// </summary>
[Flags]
public enum Component
{
    None = 0,

    [Display(Name = "Mood Tracking", Order = 1)]
    Mood = 1 << 0, // 1

    [Display(Name = "Sleep Tracking", Order = 2)]
    Sleep = 1 << 1, // 2

    [Display(Name = "People Tracking", Order = 3)]
    People = 1 << 2, // 4

    [Display(Name = "Symptom Tracking", Order = 4)]
    Symptom = 1 << 3, // 8

    [Display(Name = "Emotion Tracking", Order = 5)]
    Emotion = 1 << 4, // 16

    [Display(Name = "Activity Tracking", Order = 6)]
    Activity = 1 << 5, // 32

    [Display(Name = "Medicine Tracking", Order = 7)]
    Medicine = 1 << 6, // 64

    [Display(Name = "Acute Stress Severity Tracking", Order = 8)]
    AcuteStressSeverity = 1 << 7, // 128

    [Display(Name = "Agoraphobia Severity Tracking", Order = 9)]
    AgoraphobiaSeverity = 1 << 8, // 256

    [Display(Name = "Depression  Severity Tracking", Order = 10)]
    DepressionSeverity = 1 << 9, // 512

    [Display(Name = "Dissociative Severity Tracking", Order = 11)]
    DissociativeSeverity = 1 << 10, // 1024

    [Display(Name = "Generalized Anxiety Severity", Order = 12)]
    GeneralizedAnxietySeverity = 1 << 11, // 2048

    [Display(Name = "Panic Disorder Severity", Order = 13)]
    PanicSeverity = 1 << 12, // 4096

    [Display(Name = "PTSD Severity", Order = 14)]
    PTSDSeverity = 1 << 13, // 8192

    [Display(Name = "Social Anxiety Severity", Order = 15)]
    SocialAnxietySeverity = 1 << 14, // 16384

    [Display(Name = "Journal", Order = 99)]
    Journal = 1 << 15, // 32768

    [Display(Name = "Complete Metabolic Panel", Order = 20), SubComponent<CompleteMetabolicPanel>()]
    CompleteMetabolicPanel = 1 << 16, // 65536

    [Display(Name = "Tasks", Order = 0)]
    Tasks = 1 << 17, // 131072

    [Display(Name = "Dry Eyes", Order = 90)]
    DryEyes = 1 << 18, // 262144

    [Display(Name = "Feast Allergens", Order = 95)]
    FeastAllergens = 1 << 19, // 524288

    [Display(Name = "Cbc W Auto Differential", Order = 21), SubComponent<CbcWAutoDiff>()]
    CbcWAutoDiff = 1 << 20, // 1048576

    [Display(Name = "Blood Work", Order = 22), SubComponent<BloodWork>()]
    BloodWork = 1 << 21, // 2097152

    [Display(Name = "Depression", Order = 16)]
    Depression = 1 << 22, // 4194304

    [Display(Name = "Gut Pillars", Order = 30)]
    GutPillars = 1 << 23, // 8388608

    [Display(Name = "Gut Fungi", Order = 31)]
    GutFungi = 1 << 24, // 16777216

    All = Mood | Sleep | People | Symptom | Emotion | Activity | Medicine
        | AcuteStressSeverity | AgoraphobiaSeverity | DepressionSeverity | DissociativeSeverity
        | GeneralizedAnxietySeverity | PanicSeverity | PTSDSeverity | SocialAnxietySeverity
        | Journal | CompleteMetabolicPanel | Tasks | DryEyes | FeastAllergens | CbcWAutoDiff
        | BloodWork | Depression | GutPillars | GutFungi
}
