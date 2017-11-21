using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseLayer;
using Unity;

namespace ProductItem.Service
{
    public class ProductItemInStockService : IProductItemService
    {
        public ProductItem[] GetAllProducts()
        {
            using (var context = new ShopContext(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var helper = DependencyFactory.Container.Resolve<Helper>();
                var allProducts = context.Products.Where(x => x.QuantityInStock > 0);
                var products = new List<ProductItem>();

                foreach (var product in allProducts)
                {
                    products.Add(helper.ToProductItem(product));
                }

                return products.ToArray();
            }
        }

        public ProductItem GetProduct(int id)
        {
            using (var context = new ShopContext(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                var helper = DependencyFactory.Container.Resolve<Helper>();

                var product = context.Products.SingleOrDefault(x => x.Id == id && x.QuantityInStock > 0);

                return helper.ToProductItem(product);
            }
        }
    }
}
