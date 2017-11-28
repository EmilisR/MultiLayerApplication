using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        public User GetUser(string email)
        {
            User customer = null;

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var user = context.Customers.FirstOrDefault(x => x.Email == email);

                if (user != null)
                {
                    customer = new User()
                    {
                        Email = user.Email,
                        Id = user.Id,
                        MobileNumber = user.MobileNumber,
                        Name = user.Name,
                        Password = user.Password,
                        Surname = user.Surname
                    };
                }
            }

            return customer;
        }
    }
}
