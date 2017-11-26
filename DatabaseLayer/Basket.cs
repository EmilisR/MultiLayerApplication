using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public virtual Customer Customer { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Paid { get; set; }
    }
}
