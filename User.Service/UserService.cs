using DatabaseLayer;
using System.Linq;
using System;

namespace User.Service
{
    public class UserService : IUserService
    {
        public Repository repository = new Repository();
        public bool AddUser(User user)
        {
            try
            {
                repository.AddCustomer(new Customer()
                {
                    Email = user.Email,
                    Surname = user.Surname,
                    IsAdmin = false,
                    MobileNumber = user.MobileNumber,
                    Name = user.Name,
                    Password = user.Password
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetUser(string email)
        {
            var customer = StandardUserFactory.CreateUser();

            var user = repository.GetCustomerByEmail(email);

            return customer;
        }
    }
}
