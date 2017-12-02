using System;
using System.Security.Cryptography;
using System.Text;
using Unity;
using User.Service;

namespace LoginBLService
{
    public class FacebookLoginService : ILoginService
    {
        public bool Login(string email, string password)
        {
            return validatePassword(email, password);
        }

        private bool validatePassword(string email, string password)
        {
            var service = DependencyFactory.Container.Resolve<IUserService>();
            var realPassword = "";

            try
            {
                realPassword = service.GetUserPasswordHash(email);
            }
            catch { }
            if (realPassword != null)
            {
                if (passwordToHash(password) == realPassword)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new ArgumentNullException("Tokio vartotojo nėra");
            }
        }

        private string passwordToHash(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
