using Data.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Journal;

public class JournalViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    [Display(Name = "Journal Entries")]
    public IList<UserJournal> Journals { get; init; } = null!;
}
