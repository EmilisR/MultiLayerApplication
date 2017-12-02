using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
                        QuantityInStock = dbProduct.QuantityInStock
                    };
                }
            }

            return product;
        }

        public Product[] GetProductsArriving()
        {
            var products = new List<Product>();

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                products = context.Products.Where(x => x.QuantityArriving > 0).Select(x => new Product()
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ProductCategory = x.ProductCategory,
                    QuantityArriving = x.QuantityArriving,
                    QuantityInStock = x.QuantityInStock
                }).ToList();
            }

            return products.ToArray();
        }

        public Product[] GetProductsInStock()
        {
            var products = new List<Product>();

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                products = context.Products.Where(x => x.QuantityInStock > 0).Select(x => new Product()
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ProductCategory = x.ProductCategory,
                    QuantityArriving = x.QuantityArriving,
                    QuantityInStock = x.QuantityInStock
                }).ToList();
            }

            return products.ToArray();
        }

        public Product GetProductInStock(int itemId)
        {
            var product = new Product();

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
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
                        QuantityInStock = query.QuantityInStock
                    };
                }
            }

            return product;
        }

        public Product GetProductArriving(int itemId)
        {
            var product = new Product();

            using (var context = new ShopContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseLayer.ShopContext;Integrated Security=True;MultipleActiveResultSets=True"))
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
                        QuantityInStock = query.QuantityInStock
                    };
                }
            }

            return product;
        }
    }
}
