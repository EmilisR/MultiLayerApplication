using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryLayer.Enums;

namespace Basket.Service
{
    public class BasketCreditCard : IBasketCreditCard
    {
        public Basket GetBasket()
        {
            return new Basket()
            {
                RegisterDate = DateTime.Now,
                PaymentType = PaymentType.CreditCard
            };
        }
    }
}
