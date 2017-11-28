using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace NotificationService
{
    public class SmsNotificationService : INotificationService
    {
        public bool SendNotification(string senderContact, string message)
        {
            var regex = new Regex("^(8[0-9]{8})|(00370[0-9]{8})|([+]370[0-9]{8})&");

            return regex.IsMatch(senderContact);
        }
    }
}
