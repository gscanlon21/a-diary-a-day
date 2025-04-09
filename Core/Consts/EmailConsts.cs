
namespace Core.Consts;

/// <summary>
/// Shared email consts for Functions and Web.
/// </summary>
public class EmailConsts
{
    public const string SubjectLogin = "Account Access";

    public const string SubjectConfirm = "Account Confirmation";

    public const string SubjectDiary = "Daily Diary";

    public const string SubjectException = "Unhandled Exception";

    public const int MaxSendAttempts = 1;

    /// <summary>
    /// How many months until email logs are deleted.
    /// </summary>
    public const int DeleteEmailsAfterXMonths = 1;
}
