using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static LibraryLayer.Enums;

namespace GuiLayer.Models
{
    public class BasketViewModel
    {
        [Required]
        public BasketItemModel[] BasketItems { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public PriceItemModel PriceItem { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }
        public decimal MoneyGiven { get; set; }
    }
}