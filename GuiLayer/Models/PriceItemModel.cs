using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static LibraryLayer.Enums;

namespace GuiLayer.Models
{
    public class PriceItemModel
    {
        [Required]
        public Currency Currency { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}