using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum UserTaskType
{
    [Display(Name = "Other")]
    None,

    [Display(Name = "Supplement")]
    Supplement,
}
