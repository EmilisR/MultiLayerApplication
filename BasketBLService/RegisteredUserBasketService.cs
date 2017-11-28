using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Basket.Service;
using UserService.Service;
using Unity;

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

        public BLBasket GetBasketInfo(Basket.Service.Basket basket)
        {
            throw new NotImplementedException();
        }

        public decimal PayForBasket(string userMail, decimal moneyGiven = 0)
        {
            var userService = DependencyFactory.Container.Resolve<UserService.Service.UserService>();
            var basketService = DependencyFactory.Container.Resolve<BasketService>();

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null && !basket.Paid)
                {
                    if (basket.PaymentType == LibraryLayer.Enums.PaymentType.Cash && basket.TotalPrice <= moneyGiven)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        return moneyGiven - basket.TotalPrice;
                    }
                    if (basket.PaymentType == LibraryLayer.Enums.PaymentType.CreditCard)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        return 0;
                    }
                }
            }

            return -1;
        }
    }
}
