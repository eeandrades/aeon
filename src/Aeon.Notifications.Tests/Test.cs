using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeon.Notifications.Tests
{
    public class Messages
    {
        public record BusinessMessage(string Code, string Message, INotificationLevel Level)
            : INotification
        {
            INotificationLevel INotification.Level => this.Level;

            string INotification.FormatMessage()
            {
                return ($"{this.Level.Description}-{this.Code}-{this.Message}");
            }

            object INotification.GetContext()
            {
                throw new NotImplementedException();
            }
        }


        public static BusinessMessage ClienteNaoEncontrado = new BusinessMessage("ERR-001", "Cliente nao encontrado {IdCliente}", NotificationLevels.Error);
    }

    public class InviteClientHandler
    {
        private readonly INotificationContext _notificationContext;

        public InviteClientHandler(INotificationContext notificationContext)
        {
            this._notificationContext = notificationContext;
        }

        public int ClientId { get; }


        public void Execute()
        {


            this._notificationContext.Notify();
        }
    }
}
