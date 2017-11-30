using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Basket.Service;
using UserService.Service;
using Unity;
using Product.Service;
using NotificationService;

namespace BasketBLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RegisteredUserBasketService : IBasketBLService
    {
        public bool AddToBasket(string userMail, int itemId)
        {
            var userService = DependencyFactory.Container.Resolve<UserService.Service.UserService>();
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

            var userService = DependencyFactory.Container.Resolve<UserService.Service.UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();
            var productService = DependencyFactory.Container.Resolve<ProductService>();

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
                            Currency = LibraryLayer.Enums.Currency.EUR,
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

        public decimal PayForBasket(string userMail, LibraryLayer.Enums.PaymentType paymentType, decimal moneyGiven = 0)
        {
            var userService = DependencyFactory.Container.Resolve<UserService.Service.UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();
            var notificationService = DependencyFactory.Container.Resolve<INotificationService>();

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null && !basket.Paid)
                {
                    if (paymentType == LibraryLayer.Enums.PaymentType.Cash && basket.TotalPrice <= moneyGiven)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        basketService.SetBasketPaymentType(basket.Id, paymentType);
                        return moneyGiven - basket.TotalPrice;
                    }
                    if (paymentType == LibraryLayer.Enums.PaymentType.CreditCard)
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
