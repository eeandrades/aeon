using Microsoft.Extensions.Logging;
using System;

namespace Aeon.Notifications.Listners
{
    public class LoggerNotificationListner : INotificationListner
    {
        private readonly ILogger _logger;
        public LoggerNotificationListner(ILogger logger)
        {
            this._logger = logger;
        }

        public void Write(INotification notification)
        {
            var logLevel = notification.Level.ToLogLevel();
            Console.WriteLine(notification.FormattedMessage);
        }
    }
}
