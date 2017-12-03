using LibraryLayer;
using System.ComponentModel.DataAnnotations;

namespace GuiLayer.Models
{
    public class ProductItemModel
    {
        public ProductItemModel() { }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public int QuantityArriving { get; set; }
        [Required]
        public Enums.ProductCategory ProductCategory { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Error { get; set; }
    }
}