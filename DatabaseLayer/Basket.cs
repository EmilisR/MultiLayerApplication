using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryLayer.Enums;

namespace DatabaseLayer
{
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public double TotalPrice { get; set; }
        public virtual BasketItem[] BasketItems { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
