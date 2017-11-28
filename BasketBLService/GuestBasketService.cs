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
    public class GuestBasketService : IBasketBLService
    {
        public bool AddToBasket(string userMail, int itemId)
        {
            throw new NotImplementedException();
        }

        public BLBasket GetBasketInfo(Basket.Service.Basket basket)
        {
            throw new NotImplementedException();
        }

        public decimal PayForBasket(string userMail, decimal moneyGiven)
        {
            throw new NotImplementedException();
        }
    }
}
