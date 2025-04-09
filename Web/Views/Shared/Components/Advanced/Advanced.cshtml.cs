using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Advanced;

public class AdvancedViewModel
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public AdvancedViewModel() { }

    public AdvancedViewModel(Data.Entities.User.User user, string token)
    {
        Token = token;
        Email = user.Email;

        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
    }

    public bool IsNotDefault => FootnoteCountTop != Data.Entities.User.User.Consts.FootnoteCountTopDefault
        || FootnoteCountBottom != Data.Entities.User.User.Consts.FootnoteCountBottomDefault;

    public string Token { get; init; } = null!;
    public string Email { get; init; } = null!;

    [Display(Name = "Number of User Footnotes")]
    public int FootnoteCountTop { get; set; }

    [Display(Name = "Number of System Footnotes")]
    public int FootnoteCountBottom { get; set; }
}
