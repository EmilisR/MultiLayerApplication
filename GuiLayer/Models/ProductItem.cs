using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GuiLayer.Models
{
    public class ProductItem
    {
        [Required]
        public Bitmap Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}