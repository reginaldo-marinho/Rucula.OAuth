namespace Rucula.OAuth.LocalCredentials.Application.Notification
{
    public class NotificationErrorMessage
    {
        public NotificationErrorMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

}
