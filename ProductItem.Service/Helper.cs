﻿using System;

namespace ProductItem.Service
{
    public class Helper
    {
        public ProductItem ToProductItem(Product.Service.Product product)
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
