using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Aeon.Notifications.Listners
{
    public static class LogLevelExtension
    {
        private static readonly Dictionary<INotificationLevel, LogLevel> SMapper = new()
        {
            { NotificationLevels.Success, LogLevel.Information },
            { NotificationLevels.Info, LogLevel.Information },
            { NotificationLevels.Warning, LogLevel.Warning },
            { NotificationLevels.Error, LogLevel.Error },
            { NotificationLevels.Fatal, LogLevel.Error },
            { NotificationLevels.Critical, LogLevel.Critical}
        };

        public static LogLevel ToLogLevel(this INotificationLevel notificationLevel)
        {
            if (!SMapper.TryGetValue(notificationLevel, out LogLevel result))
            {
                result = LogLevel.None;
            }
            return result;
        }
    }
}
