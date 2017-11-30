using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuiLayer.Controllers;
using UserService.Service;
using Unity;
using Basket.Service;
using Product.Service;

namespace GuiLayer.Controllers
{
    public class BasketController : Controller
    {
        [HttpPost]
        public ActionResult AddToBasket(int itemId)
        {
            if (AccountController.LoggedIn)
            {
                var basketService = UnityConfig.Container.Resolve<BasketBLService.RegisteredUserBasketService>();

                basketService.AddToBasket(AccountController.Email, itemId);
            }

            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket");
        }

        [HttpPost]
        public ActionResult PayForBasket(BasketViewModel model)
        {
            if (AccountController.LoggedIn)
            {
                var basketService = UnityConfig.Container.Resolve<BasketBLService.RegisteredUserBasketService>();

                if (model.PaymentType == LibraryLayer.Enums.PaymentType.Cash)
                    basketService.PayForBasket(AccountController.Email, LibraryLayer.Enums.PaymentType.Cash, model.MoneyGiven);
                else
                    basketService.PayForBasket(AccountController.Email, LibraryLayer.Enums.PaymentType.CreditCard);
            }

            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket");
        }

        public ActionResult ViewBasket()
        {
            ViewBag.Message = "Pirkinių krepšelis";

            if (AccountController.LoggedIn)
            {
                var basketService = UnityConfig.Container.Resolve<BasketBLService.RegisteredUserBasketService>();
                var productService = UnityConfig.Container.Resolve<ProductService>();
                try
                {
                    var basket = basketService.GetBasketInfo(AccountController.Email);
                    return View(new BasketViewModel()
                    {
                        BasketItems = basket.BasketItems.Select(x => new BasketItemModel()
                        {
                            Quantity = x.Quantity,
                            Name = productService.GetProduct(x.ProductId).Name,
                            Price = productService.GetProduct(x.ProductId).Price,
                            ProductId = productService.GetProduct(x.ProductId).Id
                        }).ToArray(),
                        PaymentType = basket.PaymentType,
                        PriceItem = new PriceItemModel()
                        {
                            Currency = basket.Currency,
                            Price = basket.TotalPrice
                        }
                    });
                }
                catch
                {
                    return RedirectToAction(nameof(ItemController.ItemList), "Item");
                }
                
            }
            else
                return View();
        }
    }
}