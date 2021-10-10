using System.Collections.Generic;

namespace Aeon.Notifications
{
    public interface INotificationContext
    {
        IEnumerable<INotification> Notifications { get; }
        void Notify(params INotification[] notifications);

        bool IsValid { get; }

        bool IsInvalid { get; }
    }
}
