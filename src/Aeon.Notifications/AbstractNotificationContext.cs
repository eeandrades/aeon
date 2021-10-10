using System.Collections.Generic;
using System.Linq;

namespace Aeon.Notifications
{
    public abstract class AbstractNotificationContext : INotificationContext
    {
        private readonly List<INotification> _notifications = new();
        private bool _isValid = true;

        private static bool CheckValid(bool isValid, INotification[] notifications)
        {
            bool hasNotInvalid() => !notifications.Any(n => !n.Level.IsValid);
            return  isValid && hasNotInvalid();
        }

        void INotificationContext.Notify(params INotification[] notifications)
        {
            if (notifications == null || notifications.Length == 0)
            {
                return;
            }
            this._isValid = CheckValid(this._isValid, notifications);
            this._notifications.AddRange(notifications);
        }

        bool INotificationContext.IsValid => this._isValid;

        bool INotificationContext.IsInvalid => !this._isValid;

        IEnumerable<INotification> INotificationContext.Notifications => this._notifications;
    }
}
