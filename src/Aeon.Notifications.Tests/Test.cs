using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Aeon.Notifications.Tests
{

    public record ClientNotFountMessage(int ClientId, string Nome)
        : CustomNotification(1, "ClientId = {ClientId}, Nome={Nome}", NotificationLevels.Error);

    public record DuplicatedClientNotification(int ClientId, string Nome)
    : CustomNotification(2, "ClientId = {ClientId}, Nome={Nome}", NotificationLevels.Error);

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
            this._notificationContext.Notify(new ClientNotFountMessage(1, "Emerson"));
            this._notificationContext.Notify(new DuplicatedClientNotification(2, "Moby Dick"));
        }
    }

    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Exec()
        {
            INotificationContext notificationContext = new DefaultNotificationContext();
            var invite = new InviteClientHandler(notificationContext);

            invite.Execute();

            Assert.IsTrue(notificationContext.IsInvalid && notificationContext.Notifications.Any(n => n is ClientNotFountMessage));

            foreach (var not in notificationContext.Notifications)
            {
                System.Console.WriteLine(not.FormattedMessage);
            }
        }
    }
}
