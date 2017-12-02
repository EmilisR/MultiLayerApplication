using System;
using Basket.Service;
using LibraryLayer;

namespace BasketBLService
{
    public class GuestBasketService : IBasketBLService
    {
        public bool AddToBasket(string userMail, int itemId)
        {
            throw new NotImplementedException();
        }

        public BLBasket GetBasketInfo(string userMail)
        {
            throw new NotImplementedException();
        }

        public BasketItemInfo[] GetBasketItemsInfo(int basketId)
        {
            throw new NotImplementedException();
        }

        public decimal PayForBasket(string userMail, decimal moneyGiven)
        {
            throw new NotImplementedException();
        }

        public decimal PayForBasket(string userMail, Enums.PaymentType paymentType, decimal moneyGiven)
        {
            throw new NotImplementedException();
        }
    }
}
