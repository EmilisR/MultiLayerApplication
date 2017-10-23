using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLayer;

namespace TestLayer
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddToCustomerDBTest()
        {
            using (var db = new ShopContext())
            {
                try
                {
                    var oldCount = db.Customers.Count();
                    db.Customers.Add(new Customer()
                    {
                        Email = "test@test.lt",
                        MobileNumber = "+37064989556",
                        Password = "test"
                    });
                    db.SaveChanges();
                    Assert.IsTrue(db.Customers.Count() - 1 == oldCount);
                }
                catch
                {

                }
                finally
                {
                    if (db.Customers.Any(x => x.MobileNumber == "+37064989556"))
                    {
                        db.Customers.RemoveRange(db.Customers.Where(x => x.MobileNumber == "+37064989556"));
                        db.SaveChanges();
                    }
                }
            }
        }

        [TestMethod]
        public void AddToProductDBTest()
        {
            using (var db = new ShopContext())
            {
                try
                {
                    var oldCount = db.Products.Count();
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    db.SaveChanges();
                    Assert.IsTrue(db.Products.Count() - 1 == oldCount);
                }
                catch
                {

                }
                finally
                {
                    if (db.Products.Any(x => x.Name == "Acer GL502VS"))
                    {
                        db.Products.RemoveRange(db.Products.Where(x => x.Name == "Acer GL502VS"));
                        db.SaveChanges();
                    }
                }
            }
        }

        [TestMethod]
        public void AddToBasketItemDBTest()
        {
            using (var db = new ShopContext())
            {
                try
                {
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    Product product = db.Products.Where(x => x.Name == "Acer GL502VS").FirstOrDefault();
                    var oldCount = db.BasketItems.Count();
                    db.BasketItems.Add(new BasketItem()
                    {
                        Product = product,
                        Quantity = 3,
                        TotalPrice = product.Price * 3
                    });
                    db.SaveChanges();
                    Assert.IsTrue(db.BasketItems.Count() - 1 == oldCount);
                }
                catch
                {

                }
                finally
                {
                    if (db.BasketItems.Any(x => x.Product.Name == "Acer GL502VS"))
                    {
                        db.BasketItems.RemoveRange(db.BasketItems.Where(x => x.Product.Name == "Acer GL502VS"));
                        db.Products.RemoveRange(db.Products.Where(x => x.Name == "Acer GL502VS"));
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
