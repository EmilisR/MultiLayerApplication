using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LibraryLayer;

namespace Basket.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BasketService : IBasketService
    {
        public bool AddItemToBasket(int basketId, int productId)
        {
            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var dbBasket = context.Baskets.SingleOrDefault(x => x.Id == basketId);
                if (dbBasket != null)
                {
                    var basketItem = context.BasketItems.Where(x => x.Product.Id == productId && x.Basket.Id == dbBasket.Id).SingleOrDefault();
                    if (basketItem != null)
                    {
                        dbBasket.TotalPrice -= basketItem.TotalPrice;
                        basketItem.Quantity++;
                        basketItem.TotalPrice = basketItem.Product.Price * basketItem.Quantity;
                        dbBasket.TotalPrice += basketItem.TotalPrice;
                    }
                    else
                    {
                        var product = context.Products.SingleOrDefault(x => x.Id == productId);
                        if (product != null)
                        {
                            var dbBasketItem = new DatabaseLayer.BasketItem()
                            {
                                Product = product,
                                Quantity = 1,
                                TotalPrice = product.Price,
                                Basket = dbBasket
                            };
                            dbBasket.TotalPrice += dbBasketItem.TotalPrice;
                            context.BasketItems.Add(dbBasketItem);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                
                context.SaveChanges();

                return true;
            }
        }

        public Basket GetBasketForUser(int userId)
        {
            Basket basket = null;

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var dbBasket = context.Baskets.Where(x => x.Customer.Id == userId && !x.Paid).OrderByDescending(x => x.RegisterDate).FirstOrDefault();

                if (dbBasket != null)
                {
                    basket = new Basket()
                    {
                        CustomerId = dbBasket.Customer.Id,
                        Id = dbBasket.Id,
                        Paid = dbBasket.Paid,
                        PaymentType = dbBasket.PaymentType,
                        RegisterDate = dbBasket.RegisterDate,
                        TotalPrice = dbBasket.TotalPrice
                    };
                }
                else
                {
                    var customer = context.Customers.SingleOrDefault(x => x.Id == userId);

                    basket = new Basket()
                    {
                        RegisterDate = DateTime.Now,
                        Paid = false,
                        CustomerId = customer.Id
                    };

                    if (customer != null)
                    {
                        context.Baskets.Add(new DatabaseLayer.Basket()
                        {
                            RegisterDate = basket.RegisterDate,
                            Paid = basket.Paid,
                            Customer = customer,
                        });
                        context.SaveChanges();
                    }

                    return basket;
                }
            }

            return basket;
        }

        public BasketItem[] GetBasketItems(int basketId)
        {
            BasketItem[] basketItems = null;

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var basket = context.Baskets.SingleOrDefault(x => x.Id == basketId && !x.Paid);

                if (basket != null)
                {
                    basketItems = context.BasketItems.Where(x => x.Basket.Id == basket.Id).Select(x => new BasketItem()
                    {
                        BasketId = x.Basket.Id,
                        Id = x.Id,
                        ProductId = x.Product.Id,
                        Quantity = x.Quantity,
                        TotalPrice = x.TotalPrice
                    }).ToArray();
                }
            }

            return basketItems;
        }

        public void SetBasketPaid(int basketId)
        {
            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var basket = context.Baskets.SingleOrDefault(x => x.Id == basketId && !x.Paid);

                if (basket != null)
                {
                    basket.Paid = true;
                    context.SaveChanges();
                }
            }
        }

        public void SetBasketPaymentType(int basketId, Enums.PaymentType paymentType)
        {
            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var basket = context.Baskets.SingleOrDefault(x => x.Id == basketId);

                if (basket != null)
                {
                    basket.PaymentType = paymentType;
                    context.SaveChanges();
                }
            }
        }
    }
}
