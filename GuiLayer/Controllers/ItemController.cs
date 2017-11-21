using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductItem.Service;
using Unity;

namespace GuiLayer.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult ItemList(ProductItemModel model)
        {
            var service = UnityConfig.Container.Resolve<IProductItemService>();

            var products = service.GetAllProducts();

            return View(new ProductItemModel()
            {
                Products = products.Select(x => new Models.ProductItem() {Id = x.Id, Image = x.Image, Name = x.Name, Price = x.Price }).ToArray()
            });
        }
    }
}