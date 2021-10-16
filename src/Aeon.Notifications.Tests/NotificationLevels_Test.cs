using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Aeon.Notifications.Tests
{

    [TestClass]
    public class NotificationLevels_Test
    { 
        [TestMethod]
        public void NotificationLevels_SuccessMusbBeValid()=>
            Assert.IsTrue(NotificationLevels.Success.IsValid);

        [TestMethod]
        public void NotificationLevels_InfoMusbBeValid() =>
            Assert.IsTrue(NotificationLevels.Info.IsValid);

        [TestMethod]
        public void NotificationLevels_WarningMusbBeValid() =>
            Assert.IsTrue(NotificationLevels.Warning.IsValid);


        [TestMethod]
        public void NotificationLevels_ErrrorMusbBeInvalid() =>
            Assert.IsFalse(NotificationLevels.Error.IsValid);


        [TestMethod]
        public void NotificationLevels_FatalMusbBeInvalid() =>
            Assert.IsFalse(NotificationLevels.Fatal.IsValid);


        [TestMethod]
        public void NotificationLevels_CriticalMusbBeInvalid() =>
            Assert.IsFalse(NotificationLevels.Critical.IsValid);

        [TestMethod]
        public void NotificationLevels_MustHaveSixStaticsFields()
        {
            var fieldsCount = typeof(NotificationLevels).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Count(f => f.FieldType == typeof(INotificationLevel));

            Assert.IsTrue(fieldsCount == 6, "Probably a new level should be tested");
        }
    }
}
