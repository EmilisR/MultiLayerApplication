using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace Login.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LoginService : ILoginService
    {
        public bool Login(string email, string password)
        {
            return validatePassword(email, password);
        }

        private bool validatePassword(string email, string password)
        {
            var realPassword = "";

            try
            {
                realPassword = getPasswordHash(email);
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

        private string getPasswordHash(string email)
        {
            try
            {
                string password;

                using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
                {
                    password = context.Customers.Where(x => x.Email == email).SingleOrDefault().Password;
                }

                return password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
