using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductItemBLService;
using Unity;
using LibraryLayer;

namespace GuiLayer.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult ItemList(ProductItemsModel model)
        {
            var service = UnityConfig.Container.Resolve<IProductItemService>();

            var products = service.GetAllProducts();

            return View(new ProductItemsModel()
            {
                Products = products.Select(x => new ProductItemModel() {ImageUrl = x.ImageUrl, Name = x.Name, Price = x.Price, Id = x.Id }).ToArray()
            });
        }

        public ActionResult AddNewItem(ProductItemModel productItemModel)
        {
            if (ModelState.IsValid)
            {
                var service = UnityConfig.Container.Resolve<IProductItemService>();
                var success = service.AddNewProduct(new ProductItem()
                {
                    Description = productItemModel.Description,
                    ImageUrl = productItemModel.ImageUrl,
                    Name = productItemModel.Name,
                    Price = productItemModel.Price,
                    ProductCategory = productItemModel.ProductCategory,
                    QuantityArriving = productItemModel.QuantityArriving,
                    QuantityInStock = productItemModel.QuantityInStock
                });
                if (success)
                    return RedirectToAction(nameof(ItemController.ItemList), "Item");
                else
                {
                    return View(new ProductItemModel()
                    {
                        Description = "",
                        ImageUrl = "",
                        Name = "",
                        Price = 0M,
                        ProductCategory = Enums.ProductCategory.Computers,
                        QuantityArriving = 0,
                        QuantityInStock = 0,
                        Error = "Pridėti prekės nepavyko!"
                    });
                }
            }
            else if (productItemModel.Name != null)
            {
                return View(new ProductItemModel()
                {
                    Description = "",
                    ImageUrl = "",
                    Name = "",
                    Price = 0M,
                    ProductCategory = Enums.ProductCategory.Computers,
                    QuantityArriving = 0,
                    QuantityInStock = 0,
                    Error = "Pridėti prekės nepavyko!"
                });
            }
            else
            {
                return View(new ProductItemModel()
                {
                    Description = "",
                    ImageUrl = "",
                    Name = "",
                    Price = 0M,
                    ProductCategory = Enums.ProductCategory.Computers,
                    QuantityArriving = 0,
                    QuantityInStock = 0
                });
            }
        }
    }
}