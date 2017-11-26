using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Product.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public Product GetProduct(int itemId)
        {
            Product product = null;

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var dbProduct = context.Products.FirstOrDefault(x => x.Id == itemId);

                if (dbProduct != null)
                {
                    product = new Product()
                    {
                        Description = dbProduct.Description,
                        Id = dbProduct.Id,
                        Name = dbProduct.Name,
                        Price = dbProduct.Price,
                        ProductCategory = dbProduct.ProductCategory,
                        QuantityArriving = dbProduct.QuantityArriving,
                        QuantityInStock = dbProduct.QuantityInStock
                    };
                }
            }

            return product;
        }
    }
}
