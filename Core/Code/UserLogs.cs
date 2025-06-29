using Core.Interfaces.User;
using System.Collections.Concurrent;

namespace Core.Code;

public static class UserLogs
{
    private static readonly ConcurrentDictionary<int, FixedSizeQueue<string>> _userLogs = new();

    public static void Log(IUser user, string message)
    {
        if (_userLogs.TryGetValue(user.Id, out FixedSizeQueue<string>? queue))
        {
            queue.Enqueue(message);
        }
        else
        {
            _userLogs.TryAdd(user.Id, new FixedSizeQueue<string>(10, [message]));
        }
    }

    public static string? WriteLogs(IUser user)
    {
        if (_userLogs.TryRemove(user.Id, out FixedSizeQueue<string>? queue))
        {
            return string.Join(Environment.NewLine, queue);
        }
        else
        {
            return null;
        }
    }
}
