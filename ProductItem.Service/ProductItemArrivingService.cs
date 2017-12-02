using System.Collections.Generic;
using Unity;
using Product.Service;

namespace ProductItem.Service
{
    public class ProductItemArrivingService : IProductItemService
    {
        public ProductItem[] GetAllProducts()
        {
            var helper = DependencyFactory.Container.Resolve<Helper>();
            var productService = DependencyFactory.Container.Resolve<ProductService>();
            var allProducts = productService.GetProductsArriving();
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
            var product = productService.GetProductArriving(id);

            return helper.ToProductItem(product);
        }
    }
}
