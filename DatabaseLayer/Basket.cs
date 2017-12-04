using System;
using System.ComponentModel.DataAnnotations;
using LibraryLayer;

namespace DatabaseLayer
{
    public class Basket
    {
        public int Id { get; set; }
        public Enums.PaymentType PaymentType { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Paid { get; set; }
    }
}
