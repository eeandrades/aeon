namespace Aeon.Notifications
{
    public static class NotificationLevels
    {
        public static readonly INotificationLevel Success = new InternalLevel(Description: nameof(Success), IsValid: true);
        public static readonly INotificationLevel Info = new InternalLevel(Description: nameof(Info), IsValid: true);
        public static readonly INotificationLevel Warning = new InternalLevel(Description: nameof(Warning), IsValid: true);
        public static readonly INotificationLevel Error = new InternalLevel(Description: nameof(Error), IsValid: false);
        public static readonly INotificationLevel Fatal = new InternalLevel(Description: nameof(Fatal), IsValid: false);
        public static readonly INotificationLevel Critical = new InternalLevel(Description: nameof(Critical), IsValid: false);
    }
}
