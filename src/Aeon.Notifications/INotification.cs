namespace Aeon.Notifications
{
    public interface INotification
    {
        INotificationLevel Level { get; }

        string Code { get; }
        string Message { get; }
        string FormattedMessage { get; }
        object GetContext();
    }
}
