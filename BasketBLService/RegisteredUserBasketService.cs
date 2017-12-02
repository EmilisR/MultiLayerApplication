using System;
using Basket.Service;
using User.Service;
using Unity;
using Product.Service;
using NotificationService;
using LibraryLayer;
using System.Linq;

namespace BasketBLService
{
    public class RegisteredUserBasketService : IBasketBLService
    {
        public bool AddToBasket(string userMail, int itemId)
        {
            var userService = DependencyFactory.Container.Resolve<UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null)
                {
                    return !basketService.AddItemToBasket(basket.Id, itemId);
                }
            }

            return false;
        }

        public BLBasket GetBasketInfo(string userMail)
        {
            BLBasket result = null;

            var userService = DependencyFactory.Container.Resolve<UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null)
                {
                    var basketItems = basketService.GetBasketItems(basket.Id);
                    if (basketItems != null)
                    {
                        result = new BLBasket()
                        {
                            BasketItems = basketItems,
                            TotalPrice = Math.Round(basket.TotalPrice, 2),
                            Currency = Enums.Currency.EUR,
                            Id = basket.Id,
                            RegisterDate = basket.RegisterDate,
                            CustomerId = basket.CustomerId,
                            Paid = basket.Paid,
                            PaymentType = basket.PaymentType
                        };
                    }
                }
            }
            return result;
        }

        public BasketItemInfo[] GetBasketItemsInfo(int basketId)
        {
            var productService = DependencyFactory.Container.Resolve<IProductService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();

            var basketItems = basketService.GetBasketItems(basketId);
            return basketItems.Select(x => 
            {
                var product = productService.GetProduct(x.ProductId);
                return new BasketItemInfo()
                {
                    Name = product.Name,
                    Price = product.Price,
                    ProductId = product.Id,
                    Quantity = x.Quantity
                };
            }).ToArray();
        }

        public decimal PayForBasket(string userMail, Enums.PaymentType paymentType, decimal moneyGiven = 0)
        {
            var userService = DependencyFactory.Container.Resolve<UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();
            var notificationService = DependencyFactory.Container.Resolve<INotificationService>();

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null && !basket.Paid)
                {
                    if (paymentType == Enums.PaymentType.Cash && basket.TotalPrice <= moneyGiven)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        basketService.SetBasketPaymentType(basket.Id, paymentType);
                        return moneyGiven - basket.TotalPrice;
                    }
                    if (paymentType == Enums.PaymentType.CreditCard)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        basketService.SetBasketPaymentType(basket.Id, paymentType);
                        return 0;
                    }
                    notificationService.SendNotification(userMail, "Apmokėta sėkmingai");
                }
            }

            return -1;
        }
    }
}
