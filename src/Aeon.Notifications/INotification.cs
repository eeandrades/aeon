namespace Aeon.Notifications
{
    public interface INotification
    {
        string FormatMessage();
        INotificationLevel Level { get; }
        object GetContext();
    }
}
