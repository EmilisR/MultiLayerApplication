﻿using System;
using System.Security.Cryptography;
using System.Text;
using User.Service;
using Unity;

namespace LoginBLService
{
    public class LoginService : ILoginService
    {
        public bool Login(string email, string password)
        {
            return ValidatePassword(email, password);
        }

        private bool ValidatePassword(string email, string password)
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
                if (PasswordToHash(password) == realPassword)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new ArgumentNullException("Tokio vartotojo nėra");
            }
        }

        private string PasswordToHash(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
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
