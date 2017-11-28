using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductItem.Service
{
    public class Helper
    {
        public ProductItem ToProductItem(DatabaseLayer.Product product)
        {
            if (product == null)
                throw new Exception("product is null");

            return new ProductItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
