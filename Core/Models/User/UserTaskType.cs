using Core.Attributes;
using Core.Models.Components.SubComponents;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum UserTaskType
{
    [Display(Name = "Other")]
    None,

    [Display(Name = "Supplement")]
    Supplement,

    [Display(Name = "Mood Tracking")]
    Mood,

    [Display(Name = "Sleep Tracking")]
    Sleep,

    [Display(Name = "People Tracking")]
    People,

    [Display(Name = "Symptom Tracking")]
    Symptom,

    [Display(Name = "Emotion Tracking")]
    Emotion,

    [Display(Name = "Activity Tracking")]
    Activity,

    [Display(Name = "Medicine Tracking")]
    Medicine,

    [Display(Name = "Acute Stress Severity Tracking")]
    AcuteStressSeverity,

    [Display(Name = "Agoraphobia Severity Tracking")]
    AgoraphobiaSeverity,

    [Display(Name = "Depression  Severity Tracking")]
    DepressionSeverity,

    [Display(Name = "Dissociative Severity Tracking")]
    DissociativeSeverity,

    [Display(Name = "Generalized Anxiety Severity")]
    GeneralizedAnxietySeverity,

    [Display(Name = "Panic Disorder Severity")]
    PanicSeverity,

    [Display(Name = "PTSD Severity")]
    PTSDSeverity,

    [Display(Name = "Social Anxiety Severity")]
    SocialAnxietySeverity,

    [Display(Name = "Journal")]
    Journal,

    [Display(Name = "Complete Metabolic Panel"), SubComponent<CompleteMetabolicPanel>()]
    CompleteMetabolicPanel,

    [Display(Name = "Dry Eyes")]
    DryEyes,

    [Display(Name = "Feast Allergens")]
    FeastAllergens,

    [Display(Name = "Cbc W Auto Differential"), SubComponent<CbcWAutoDiff>()]
    CbcWAutoDiff,

    [Display(Name = "Blood Work"), SubComponent<BloodWork>()]
    BloodWork,

    [Display(Name = "Depression")]
    Depression,
}
