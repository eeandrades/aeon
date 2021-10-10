using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aeon.Notifications.Tests
{

    [TestClass]
    public class NotificationContext_Test
    {
        INotificationContext _notificatonContext = new DefaultNotificationContext();

        private INotificationLevel CreateLevel(bool isValid)
        {
            var mockNotificationLevel = new Moq.Mock<INotificationLevel>();

            mockNotificationLevel
                .Setup(l => l.IsValid)
                .Returns(isValid);
            return mockNotificationLevel.Object;
        }

        private INotification CreateNotification(INotificationLevel level)
        {
            var mockNotification = new Moq.Mock<INotification>();

            mockNotification
                .Setup(f => f.Level)
                .Returns(() => level);

            return mockNotification.Object;
        }


        INotificationLevel GetErrorLevel()
        {
            return NotificationLevels.Info;
        }


        [TestMethod]
        public void NotificationContext_When_HasInvalid()
        {
            var validLevel = this.CreateLevel(true);
            var invalidLevel = this.CreateLevel(false);

            this._notificatonContext.Notify(this.CreateNotification(validLevel));
            this._notificatonContext.Notify(this.CreateNotification(invalidLevel));
            this._notificatonContext.Notify(this.CreateNotification(validLevel));

            Assert.IsTrue(_notificatonContext.IsInvalid && !this._notificatonContext.IsValid);
        }

        [TestMethod]
        public void NotificationContext_When_AllIsValid()
        {
            var validLevel = this.CreateLevel(true);

            this._notificatonContext.Notify(this.CreateNotification(validLevel));
            this._notificatonContext.Notify(this.CreateNotification(validLevel));
            this._notificatonContext.Notify(this.CreateNotification(validLevel));

            Assert.IsTrue(!_notificatonContext.IsInvalid && this._notificatonContext.IsValid);
        }


        [TestMethod]
        public void NotificationContext_When_WithRange_HasInvalid()
        {
            var validLevel = this.CreateLevel(true);
            var invalidLevel = this.CreateLevel(false);

            var notifications = new[]
            {
                this.CreateNotification(validLevel),
                this.CreateNotification(invalidLevel),
                this.CreateNotification(validLevel)
            };

            this._notificatonContext.Notify(notifications);

            Assert.IsTrue(_notificatonContext.IsInvalid && !this._notificatonContext.IsValid);
        }

        [TestMethod]
        public void NotificationContext_When_WithRange_AllIsValid()
        {
            var validLevel = this.CreateLevel(true);

            this._notificatonContext.Notify(this.CreateNotification(validLevel));
            this._notificatonContext.Notify(this.CreateNotification(validLevel));
            this._notificatonContext.Notify(this.CreateNotification(validLevel));

            Assert.IsTrue(!_notificatonContext.IsInvalid && this._notificatonContext.IsValid);
        }
    }
}
