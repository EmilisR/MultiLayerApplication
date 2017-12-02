using Product.Service;
using System.Collections.Generic;
using Unity;

namespace ProductItemBLService
{
    public class ProductItemInStockService : IProductItemService
    {
        public ProductItem[] GetAllProducts()
        {
            var helper = DependencyFactory.Container.Resolve<Helper>();
            var productService = DependencyFactory.Container.Resolve<ProductService>();
            var allProducts = productService.GetProductsInStock();
            var products = new List<ProductItem>();

            foreach (var product in allProducts)
            {
                products.Add(helper.ToProductItem(product));
            }

            return products.ToArray();
        }

        public ProductItem GetProduct(int id)
        {
            var helper = DependencyFactory.Container.Resolve<Helper>();
            var productService = DependencyFactory.Container.Resolve<ProductService>();
            var product = productService.GetProductInStock(id);

            return helper.ToProductItem(product);
        }
    }
}
