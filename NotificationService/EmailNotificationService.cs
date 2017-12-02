using System.Text.RegularExpressions;

namespace NotificationService
{
    public class EmailNotificationService : INotificationService
    {
        public bool SendNotification(string senderContact, string message)
        {
            var regex = new Regex("^[a-zA-Z0-9.]{1,}@[a-zA-Z0-9]{1,}.[a-z]{1,}&");

            return regex.IsMatch(senderContact);
        }
    }
}
