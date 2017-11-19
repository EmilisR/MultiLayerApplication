using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLayer;
using System;
using Login.Service;

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
                catch (Exception ex)
                {
                    throw ex;
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
                catch (Exception ex)
                {
                    throw ex;
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
        public void AddToProductDB()
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
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    db.Products.Add(new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    });
                    db.SaveChanges();
                    Assert.IsTrue(db.Products.Count() - 5 == oldCount);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [TestMethod]
        public void PasswordTest()
        {
            using (var db = new ShopContext())
            {
                try
                {
                    db.Customers.Add(new Customer()
                    {
                        Email = "emilis@ruzveltas.lt",
                        Password = "872a863b80ed19d8df1a95e073f68535c6d0a6713d1d7f3ed80d17ced3482585"
                    });
                    db.SaveChanges();

                    var service = new LoginService();
                    Assert.IsTrue(service.Login("emilis@ruzveltas.lt", "emilis"));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    db.Customers.RemoveRange(db.Customers.Where(x => x.Email == "emilis@ruzveltas.lt"));
                    db.SaveChanges();
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
                    db.SaveChanges();
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
                catch (Exception ex)
                {
                    throw ex;
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

        [TestMethod]
        public void AddToBasketDBTest()
        {
            using (var db = new ShopContext())
            {
                try
                {
                    var oldCount = db.BasketItems.Count();

                    Product product = new Product()
                    {
                        Name = "Acer GL502VS",
                        Description = "Gaming laptop",
                        Price = 1799.99M,
                        ProductCategory = LibraryLayer.Enums.ProductCategory.Computers
                    };
                    BasketItem basketItem = new BasketItem()
                    {
                        Product = product,
                        Quantity = 3
                    };
                    basketItem.TotalPrice = basketItem.Product.Price * basketItem.Quantity;
                    Customer customer = new Customer()
                    {
                        Email = "emilis@ruzveltas.lt",
                        MobileNumber = "+37064589699",
                        Name = "Emilis",
                        Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                        Surname = "Ruzveltas"
                    };
                    Basket basket = new Basket()
                    {
                        BasketItems = new BasketItem[]
                        {
                            basketItem
                        },
                        Customer = customer,
                        PaymentType = LibraryLayer.Enums.PaymentType.Cash
                    };
                    basket.TotalPrice = basket.BasketItems.Select(x => x.TotalPrice).Sum();
                    db.Baskets.Add(basket);
                    db.SaveChanges();
                    var a = db.Baskets.ToList();
                    Assert.IsTrue(db.Baskets.Count() - 1 == oldCount);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.Baskets.Any(x => x.Customer.Name == "Emilis"))
                    {
                        db.Baskets.RemoveRange(db.Baskets.Where(x => x.Customer.Email == "emilis@ruzveltas.lt"));
                        db.Customers.RemoveRange(db.Customers.Where(x => x.Email == "emilis@ruzveltas.lt"));
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
