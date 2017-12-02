using System.ServiceModel;

namespace LoginBLService
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool Login(string email, string password);
    }
}
