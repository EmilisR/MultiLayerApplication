using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryLayer.Enums;

namespace DatabaseLayer
{
    public class Basket
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual BasketItem[] BasketItems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
