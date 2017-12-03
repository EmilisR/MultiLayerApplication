using DatabaseLayer;
using System.Collections.Generic;
using System.Linq;

namespace Product.Service
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int itemId)
        {
            Product product = null;

            using (var context = new ShopContext())
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
                        QuantityInStock = dbProduct.QuantityInStock,
                        ImageUrl = dbProduct.ImageUrl
                    };
                }
            }

            return product;
        }

        public Product[] GetProductsArriving()
        {
            var products = new List<Product>();

            using (var context = new ShopContext())
            {
                products = context.Products.Where(x => x.QuantityArriving > 0).Select(x => new Product()
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ProductCategory = x.ProductCategory,
                    QuantityArriving = x.QuantityArriving,
                    QuantityInStock = x.QuantityInStock,
                    ImageUrl = x.ImageUrl
                }).ToList();
            }

            return products.ToArray();
        }

        public Product[] GetProductsInStock()
        {
            var products = new List<Product>();

            using (var context = new ShopContext())
            {
                products = context.Products.Where(x => x.QuantityInStock > 0).Select(x => new Product()
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ProductCategory = x.ProductCategory,
                    QuantityArriving = x.QuantityArriving,
                    QuantityInStock = x.QuantityInStock,
                    ImageUrl = x.ImageUrl
                }).ToList();
            }

            return products.ToArray();
        }

        public Product GetProductInStock(int itemId)
        {
            var product = new Product();

            using (var context = new ShopContext())
            {
                var query = context.Products.Where(x => x.QuantityInStock > 0 && x.Id == itemId).SingleOrDefault();

                if (query != null)
                {
                    product = new Product()
                    {
                        Description = query.Description,
                        Id = query.Id,
                        Name = query.Name,
                        Price = query.Price,
                        ProductCategory = query.ProductCategory,
                        QuantityArriving = query.QuantityArriving,
                        QuantityInStock = query.QuantityInStock,
                        ImageUrl = query.ImageUrl
                    };
                }
            }

            return product;
        }

        public Product GetProductArriving(int itemId)
        {
            var product = new Product();

            using (var context = new ShopContext())
            {
                var query = context.Products.Where(x => x.QuantityArriving > 0 && x.Id == itemId).SingleOrDefault();

                if (query != null)
                {
                    product = new Product()
                    {
                        Description = query.Description,
                        Id = query.Id,
                        Name = query.Name,
                        Price = query.Price,
                        ProductCategory = query.ProductCategory,
                        QuantityArriving = query.QuantityArriving,
                        QuantityInStock = query.QuantityInStock,
                        ImageUrl = query.ImageUrl
                    };
                }
            }

            return product;
        }

        public bool AddNewProduct(Product product)
        {
            try
            {
                using (var context = new ShopContext())
                {
                    context.Products.Add(new DatabaseLayer.Product()
                    {
                        ImageUrl = product.ImageUrl,
                        Name = product.Name,
                        Price = product.Price,
                        QuantityArriving = product.QuantityArriving,
                        QuantityInStock = product.QuantityInStock,
                        Description = product.Description,
                        ProductCategory = product.ProductCategory
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
