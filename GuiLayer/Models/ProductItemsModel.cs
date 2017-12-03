using System.ComponentModel.DataAnnotations;
using LibraryLayer;

namespace GuiLayer.Models
{
    public class ProductItemsModel
    {
        [Required]
        public ProductItemModel[] Products { get; set; }
        [Required]
        public Enums.QuantitySource QuantitySource { get; set; }
    }
}