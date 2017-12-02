using System;
using System.Configuration;
using System.Data.Entity;

namespace DatabaseLayer
{
    public class ShopContext : DbContext, IDisposable
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public ShopContext(string connectionString) : base(connectionString)
        {
            Database.CreateIfNotExists();
        }
        public ShopContext() : base(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString)
        {
            Database.CreateIfNotExists();
        }
    }
}
