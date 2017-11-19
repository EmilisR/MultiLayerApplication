using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseLayer;

namespace ProductItem.Service
{
    public class ProductItemService : IProductItemService
    {
        public ProductItem[] GetAllProducts()
        {
            using (var context = new ShopContext(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var helper = new Helper();
                var allProducts = context.Products.ToArray();
                var products = new List<ProductItem>();

                foreach (var product in allProducts)
                {
                    products.Add(helper.ToProductItem(product));
                }

                return products.ToArray();
            }
        }
    }
}
