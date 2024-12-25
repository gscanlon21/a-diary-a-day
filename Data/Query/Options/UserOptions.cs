namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public int? Id { get; }
    public bool NoUser { get; } = true;
    public DateOnly CreatedDate { get; }

    public bool? Ignored { get; set; } = null;

    public UserOptions() { }

    public UserOptions(Entities.User.User user)
    {
        Id = user.Id;
        NoUser = false;
        CreatedDate = user.CreatedDate;
    }
}
