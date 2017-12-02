using System.ServiceModel;

namespace NotificationService
{
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract]
        bool SendNotification(string senderContact, string message);
    }
}
