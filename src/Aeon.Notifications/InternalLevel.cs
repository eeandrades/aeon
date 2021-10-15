namespace Aeon.Notifications
{
    internal record InternalLevel(string Description, bool IsValid) : INotificationLevel;
}
