using System.Runtime.Serialization;
using System.ServiceModel;

namespace User.Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(string email);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
    }
}
