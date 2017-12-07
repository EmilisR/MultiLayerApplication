using System.ServiceModel;

namespace BasketBLService
{
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract]
        bool SendNotification(string senderContact, string message);
    }
}
