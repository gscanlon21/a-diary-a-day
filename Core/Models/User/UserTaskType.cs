using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

/// <summary>
/// The type of the task.
/// </summary>
public enum UserTaskType
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Supplement")]
    Supplement = 1,

    [Display(Name = "Log")]
    Log = 2,
}
