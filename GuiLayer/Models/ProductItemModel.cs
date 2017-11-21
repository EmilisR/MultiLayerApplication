using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using static LibraryLayer.Enums;

namespace GuiLayer.Models
{
    public class ProductItemModel
    {
        [Required]
        public ProductItem[] Products { get; set; }
        [Required]
        public QuantitySource QuantitySource { get; set; }
    }
}