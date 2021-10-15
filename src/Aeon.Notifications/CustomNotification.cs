using System;
using System.Text;

namespace Aeon.Notifications
{
    public abstract record CustomNotification(int Code, string TemplateMessage, INotificationLevel Level) : INotification
    {
        INotificationLevel INotification.Level => this.Level;

        string INotification.Message => MessageFormatter.Format(TemplateMessage, this);

        string INotification.Code => $"{Level.Description.ToUpper()}-{Convert.ToString(this.Code).PadLeft(4, '0')}";

        string INotification.FormattedMessage => $"{(this as INotification).Code}: {(this as INotification).Message}";

        object INotification.GetContext()
        {
            return this;
        }     
    }
}
