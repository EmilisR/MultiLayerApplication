using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace NotificationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmailNotificationService : INotificationService
    {
        public bool SendNotification(string senderContact, string message)
        {
            var regex = new Regex("^[a-zA-Z0-9.]{1,}@[a-zA-Z0-9]{1,}.[a-z]{1,}&");

            return regex.IsMatch(senderContact);
        }
    }
}
