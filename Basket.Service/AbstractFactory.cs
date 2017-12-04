using LibraryLayer;
using System;

namespace Basket.Service
{
    public static class NormalBasketFactory
    {
        public static Basket CreateBasket()
        {
            var basket = new Basket()
            {
                Paid = false,
                RegisterDate = DateTime.Now
            };
            basket.Id = BasketService.CreateBasket(basket);
            return basket;
        }
    }


    public static class GuestBasketFactory
    {
        public static Basket CreateBasket()
        {
            var basket = new Basket()
            {
                Paid = false,
                RegisterDate = DateTime.Now,
                PaymentType = Enums.PaymentType.CreditCard
            };
            basket.Id = BasketService.CreateBasket(basket);
            return basket;
        }
    }
}
