using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

/// <summary>
/// The detail shown in the newsletter.
/// </summary>
[Flags]
public enum Verbosity
{
    None = 0,

    /// <summary>
    /// Show images to the user.
    /// </summary>
    [Display(Name = "Images")]
    Images = 1 << 0, // 1

    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Debug = Images 
        | 1 << 30 // 1073741824
}
