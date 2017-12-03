using Product.Service;
using System.Collections.Generic;
using Unity;

namespace ProductItemBLService
{
    public class ProductItemInStockService : IProductItemService
    {
        public bool AddNewProduct(ProductItem productItem)
        {
            var productService = DependencyFactory.Container.Resolve<IProductService>();

            var success = productService.AddNewProduct(new Product.Service.Product()
            {
                ImageUrl = productItem.ImageUrl,
                Name = productItem.Name,
                Price = productItem.Price,
                Description = productItem.Description,
                ProductCategory = productItem.ProductCategory,
                QuantityArriving = productItem.QuantityArriving,
                QuantityInStock = productItem.QuantityInStock,
            });
            return success;
        }

        public ProductItem[] GetAllProducts()
        {
            var helper = DependencyFactory.Container.Resolve<Helper>();
            var productService = DependencyFactory.Container.Resolve<IProductService>();
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
            var productService = DependencyFactory.Container.Resolve<IProductService>();
            var product = productService.GetProductInStock(id);

            return helper.ToProductItem(product);
        }
    }
}
