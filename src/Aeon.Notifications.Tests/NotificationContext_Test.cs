using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aeon.Notifications.Tests
{

    [TestClass]
    public class NotificationContext_Test
    {
        private readonly static Listners.INotificationListner[] SListners = new[]
        {
            new Listners.LoggerNotificationListner(null)
        };


        readonly INotificationContext _notificatonContext = new DefaultNotificationContext(SListners);

        private static INotificationLevel CreateLevel(bool isValid)
        {
            var mockNotificationLevel = new Moq.Mock<INotificationLevel>();

            mockNotificationLevel
                .Setup(l => l.IsValid)
                .Returns(isValid);
            return mockNotificationLevel.Object;
        }

        private static INotification CreateNotification(INotificationLevel level)
        {
            var mockNotification = new Moq.Mock<INotification>();

            mockNotification
                .Setup(f => f.Level)
                .Returns(() => level);

            return mockNotification.Object;
        }

        [TestMethod]
        public void NotificationContext_When_HasInvalid()
        {
            var validLevel = CreateLevel(true);
            var invalidLevel = CreateLevel(false);

            this._notificatonContext.Notify(CreateNotification(validLevel));
            this._notificatonContext.Notify(CreateNotification(invalidLevel));
            this._notificatonContext.Notify(CreateNotification(validLevel));

            Assert.IsTrue(_notificatonContext.IsInvalid && !this._notificatonContext.IsValid);
        }

        [TestMethod]
        public void NotificationContext_When_AllIsValid()
        {
            var validLevel = CreateLevel(true);

            this._notificatonContext.Notify(CreateNotification(validLevel));
            this._notificatonContext.Notify(CreateNotification(validLevel));
            this._notificatonContext.Notify(CreateNotification(validLevel));

            Assert.IsTrue(!_notificatonContext.IsInvalid && this._notificatonContext.IsValid);
        }
    }
}
