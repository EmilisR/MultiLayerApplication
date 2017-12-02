using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual Basket Basket { get; set; }
    }
}
