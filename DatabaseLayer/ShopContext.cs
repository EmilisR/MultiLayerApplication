using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseLayer
{
    public class ShopContext : DbContext, IDisposable
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public ShopContext()
        {
            Database.CreateIfNotExists();
        }
        public ShopContext(string connectionString) : base(connectionString)
        {
            Database.CreateIfNotExists();
        }
    }
}
