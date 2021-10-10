namespace Aeon.Notifications
{
    public static class NotificationLevels
    {
        public static INotificationLevel Success = new InternalLevel(Description:nameof(Success), IsValid:true);
        public static INotificationLevel Info = new InternalLevel(Description: nameof(Info), IsValid: true);
        public static INotificationLevel Warning = new InternalLevel(Description: nameof(Warning), IsValid: true);
        public static INotificationLevel Error = new InternalLevel(Description: nameof(Error), IsValid: false);
        public static INotificationLevel Fatal = new InternalLevel(Description: nameof(Fatal), IsValid: false);
        public static INotificationLevel Critical = new InternalLevel(Description: nameof(Critical), IsValid: false);
    }
}
