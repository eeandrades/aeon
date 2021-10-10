namespace Aeon.Notifications
{
    public static class NotificationExtensions
    {
        public static void NotifySuccess(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Error, parameters));

        public static void NotifyInfo(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Info, parameters));

        public static void NotifyWarning(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Warning, parameters));

        public static void NotifyError(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Error, parameters));

        public static void NotifyFatal(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Fatal, parameters));

        public static void NotifyCritical(this INotificationContext context, string errorMessage, params object[] parameters) =>
            context.Notify(new SimpleNotification(errorMessage, NotificationLevels.Critical, parameters));
    }
}
