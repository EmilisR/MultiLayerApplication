using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Basket.Service;

namespace BasketBLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RegisteredUserBasketService : IBasketBLService
    {
        public bool AddToBasket(Basket.Service.Basket basket, BasketItem basketItem)
        {
            var userService = UnityConfig.Container.Resolve<UserService>();
            var basketService = UnityConfig.Container.Resolve<BasketService>();
            var productService = UnityConfig.Container.Resolve<ProductService>();

            var user = userService.GetUser(AccountController.Email);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null)
                {
                    if (!basketService.AddItemToBasket(basket, itemId))
                        return View();
                }
            }
        }

        public BLBasket GetBasketInfo(Basket.Service.Basket basket)
        {
            throw new NotImplementedException();
        }

        public decimal PayForBasket(Basket.Service.Basket basket, decimal moneyGiven)
        {
            throw new NotImplementedException();
        }
    }
}
