using System;
using System.Collections.Generic;
using System.Linq;

namespace Aeon.Notifications
{
    public abstract class AbstractNotificationContext : INotificationContext
    {
        private readonly List<INotification> _notifications = new();
        private bool _isValid = true;

        protected AbstractNotificationContext(IEnumerable<Listners.INotificationListner> listners)
        {
            this.Listners = listners;
        }
        private void PostListners(INotification notification)
        {
            foreach (var listner in this.Listners)
            {
                listner.Write(notification);
            }
        }
        public IEnumerable<Listners.INotificationListner> Listners { get; }

        private static bool CheckValid(bool isValid, INotification notification)
        {
            return isValid && notification.Level.IsValid;
        }

        void INotificationContext.Notify(INotification notification)
        {
            if (notification is null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            this._isValid = CheckValid(this._isValid, notification);
            this._notifications.Add(notification);

            this.PostListners(notification);
        }

        bool INotificationContext.IsValid => this._isValid;

        bool INotificationContext.IsInvalid => !this._isValid;

        IEnumerable<INotification> INotificationContext.Notifications => this._notifications;
    }
}
