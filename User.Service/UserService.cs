using DatabaseLayer;
using System.Linq;

namespace User.Service
{
    public class UserService : IUserService
    {
        public User GetUser(string email)
        {
            User customer = null;

            using (var context = new ShopContext())
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

        public string GetUserFirstName(string email)
        {
            var name = string.Empty;

            using (var context = new ShopContext())
            {
                var user = context.Customers.Where(x => x.Email == email);
                if (user.Count() == 1)
                {
                    name = user.First().Name;
                }
            }

            return name;
        }

        public string GetUserPasswordHash(string email)
        {
            var name = string.Empty;

            using (var context = new ShopContext())
            {
                var user = context.Customers.Where(x => x.Email == email);
                if (user.Count() == 1)
                {
                    name = user.First().Password;
                }
            }

            return name;
        }
    }
}
