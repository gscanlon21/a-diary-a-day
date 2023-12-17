using Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

public class JournalViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    [Display(Name = "Journal Entries")]
    public IList<UserJournal> Journals { get; init; } = null!;
}
