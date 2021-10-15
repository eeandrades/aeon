﻿using System.Text;

namespace Aeon.Notifications
{
    public record SimpleNotification(string templateMessage, INotificationLevel Level, object Context = default) : INotification
    {
        string INotification.Message { get; } = MessageFormatter.Format(templateMessage, Context);

        INotificationLevel INotification.Level => this.Level;

        string INotification.Code => string.Empty;

        object INotification.GetContext()
        {
            return this.Context ?? new { };
        }

        string INotification.FormattedMessage => $"{(this as INotification).Message}";
    }
}
