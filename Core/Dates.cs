namespace Core;

public static class Dates
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    public static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);
}
