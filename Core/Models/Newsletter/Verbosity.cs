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
    /// Show notes to the user.
    /// </summary>
    [Display(Name = "Notes")]
    Notes = 1 << 1, // 2

    /// <summary>
    /// Show section to the user.
    /// 
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Section = 1 << 2, // 4

    /// <summary>
    /// Show lag refresh to the user.
    /// 
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    LagRefresh = 1 << 3, // 8

    /// <summary>
    /// Show pad refresh to the user.
    /// 
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    PadRefresh = 1 << 4, // 16

    /// <summary>
    /// Show enabled to the user.
    /// 
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Enabled = 1 << 5, // 32

    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Debug = Images | Notes | Section | LagRefresh | PadRefresh | Enabled
        | 1 << 30 // 1073741824
}
