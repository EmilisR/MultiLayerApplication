using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class Repository
    {
        public int AddCustomer(Customer customer)
        {
            using (var context = new ShopContext())
            {
                var id = context.Customers.Add(new Customer()
                {
                    Email = customer.Email,
                    IsAdmin = false,
                    MobileNumber = customer.MobileNumber,
                    Name = customer.Name,
                    Password = customer.Password,
                    Surname = customer.Surname
                }).Id;
                context.SaveChanges();
                return id;
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            using (var context = new ShopContext())
            {
                return context.Customers.FirstOrDefault(x => x.Email == email);
            }
        }
    }
}
