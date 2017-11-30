using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Service
{
    public interface IBasket
    {
        IBasketCash GetBasketCash();
        IBasketCreditCard GetBasketCreditCard();
    }
}
