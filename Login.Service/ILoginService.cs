using System.Runtime.Serialization;
using System.ServiceModel;

namespace LoginBLService
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool Login(string email, string password);
        [OperationContract]
        string GetUserName(string email);
        [OperationContract]
        bool IsAdmin(string email);
        [OperationContract]
        bool Register(RegisterInfo registerInfo);
    }

    [DataContract]
    public class RegisterInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
