using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryLayer.Enums;

namespace Basket.Service
{
    public class BasketCash : IBasketCash
    {
        public Basket GetBasket()
        {
            return new Basket()
            {
                RegisterDate = DateTime.Now,
                PaymentType = PaymentType.Cash
            };
        }
    }
}
