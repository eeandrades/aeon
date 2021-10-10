using System;
using System.Text;
using System.Threading.Tasks;

namespace Aeon.Notifications
{
    internal record SimpleNotification(string Message, INotificationLevel Level, params object[] Parameters) : INotification
    {
        INotificationLevel INotification.Level => this.Level;

        public object GetContext()
        {
            return this.Parameters;
        }

        string INotification.FormatMessage()
        {
            return string.Format(this.Message, Parameters);
        }
    }
}
