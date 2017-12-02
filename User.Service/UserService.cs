using DatabaseLayer;
using System.Linq;
using System;

namespace User.Service
{
    public class UserService : IUserService
    {
        public User GetUser(string email)
        {
            var customer = StandardUserFactory.CreateUser();
            using (var context = new ShopContext())
            {
                var user = context.Customers.FirstOrDefault(x => x.Email == email);

                if (user != null)
                {
                    customer.Email = user.Email;
                    customer.Id = user.Id;
                    customer.MobileNumber = user.MobileNumber;
                    customer.Name = user.Name;
                    customer.Password = user.Password;
                    customer.Surname = user.Surname;
                }
            }

            return customer;
        }
    }
}
