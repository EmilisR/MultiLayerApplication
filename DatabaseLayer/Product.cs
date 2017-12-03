using System.ComponentModel.DataAnnotations;
using LibraryLayer;

namespace DatabaseLayer
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantityArriving { get; set; }
        public Enums.ProductCategory ProductCategory { get; set; }
        public string ImageUrl { get; set; }

    }
}
