using Aeon.Notifications.Listners;
using System.Collections.Generic;

namespace Aeon.Notifications
{
    public class DefaultNotificationContext : AbstractNotificationContext
    {
        public DefaultNotificationContext(IEnumerable<INotificationListner> listners) : base(listners)
        {
        }
    }
}
