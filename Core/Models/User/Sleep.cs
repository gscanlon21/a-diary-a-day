
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum SleepDuration
{
    [Display(Name = "Too Little")]
    TooLittle = 1,

    [Display(Name = "Just Right")]
    JustRight = 2,

    [Display(Name = "Too Much")]
    TooMuch = 3
}


public enum SleepTime
{
    [Display(Name = "Early to Bed")]
    EarlyToBed = 1,

    [Display(Name = "In Bed on Time")]
    InBedOnTime = 2,

    [Display(Name = "Late to Bed")]
    LateToBed = 3,
}
