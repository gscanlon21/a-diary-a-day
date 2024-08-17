using System.ComponentModel.DataAnnotations;

namespace Core.Models.Footnote;

[Flags]
public enum FootnoteType
{
    [Display(Name = "None")]
    None = 0,

    /// <summary>
    /// Life advice and tips.
    /// 
    /// sa. Practicing everyday mindfulness can improve your memory and concentration skills....
    /// </summary>
    [Display(Name = "Health Tips", Description = "sa. Practicing everyday mindfulness can improve your memory and concentration skills...")]
    HealthTips = 1 << 0, // 1

    /// <summary>
    /// User defined footnotes.
    /// </summary>
    [Display(Name = "Health Facts", Description = "sa. Waking up earlier is healthier than going to bed later when trying to limit the damage of sleep deprivation.")]
    HealthFacts = 1 << 1, // 2

    /// <summary>
    /// Life motivation.
    /// 
    /// sa. Never give up!
    /// </summary>
    [Display(Name = "Life Motivation", Description = "sa. Never give up!")]
    LifeMotivation = 1 << 2, // 4

    /// <summary>
    /// Life affirmations. 
    /// 
    /// sa. I'm a thoughtful and interesting person.
    /// </summary>
    [Display(Name = "Life Affirmations", Description = "sa. I'm a thoughtful and interesting person.")]
    LifeAffirmations = 1 << 3, // 8

    /// <summary>
    /// Mindfulness
    /// 
    /// sa. Breathe deeply. You are in the present moment.
    /// </summary>
    [Display(Name = "Mindfulness", Description = "sa. Breathe deeply. You are in the present moment.")]
    Mindfulness = 1 << 4, // 16

    /// <summary>
    /// Good vibes. Re-parenting.
    /// 
    /// sa. You are beautiful!
    /// </summary>
    [Display(Name = "Good Vibes", Description = "sa. You are beautiful!")]
    GoodVibes = 1 << 5, // 32

    /// <summary>
    /// User defined footnotes.
    /// </summary>
    [Display(Name = "Custom", Description = "sa. You are beautiful!")]
    Custom = 1 << 10, // 1024

    System = All & ~Custom, // FitnessTips | FitnessFacts | FitnessMotivation | FitnessAffirmations | HealthTips | HealthFacts | LifeMotivation | LifeAffirmations | GoodVibes | Mindfulness

    All = HealthTips | HealthFacts | LifeMotivation | LifeAffirmations | GoodVibes | Mindfulness | Custom
}
