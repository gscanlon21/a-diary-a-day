namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;

    public int Id { get; }
    public DateOnly CreatedDate { get; }

    public bool? Ignored { get; set; } = null;

    public UserOptions() { }

    public UserOptions(Entities.User.User user)
    {
        NoUser = false;
        Id = user.Id;
        CreatedDate = user.CreatedDate;
    }
}
