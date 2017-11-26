using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuiLayer.Controllers;
using User.Service;
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
                var userService = UnityConfig.Container.Resolve<UserService>();
                var basketService = UnityConfig.Container.Resolve<BasketService>();
                var productService = UnityConfig.Container.Resolve<ProductService>();

                var user = userService.GetUser(AccountController.Email);
                if (user != null)
                {
                    var basket = basketService.GetBasketForUser(user.Id);
                    if (basket != null)
                    {
                        if (!basketService.AddItemToBasket(basket, itemId))
                            return View();
                    }
                }
            }

            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket");
        }

        [HttpPost]
        public ActionResult PayForBasket(BasketViewModel model)
        {
            ViewBag.Message = "Apmokėjimas";
            return View(model);
        }

        public ActionResult ViewBasket()
        {
            ViewBag.Message = "Pirkinių krepšelis";

            if (AccountController.LoggedIn)
            {
                var userService = UnityConfig.Container.Resolve<UserService>();
                var basketService = UnityConfig.Container.Resolve<BasketService>();
                var productService = UnityConfig.Container.Resolve<ProductService>();
                
                var user = userService.GetUser(AccountController.Email);
                if (user != null)
                {
                    var basket = basketService.GetBasketForUser(user.Id);
                    if (basket != null)
                    {
                        var basketItems = basketService.GetBasketItems(basket.Id);
                        if (basketItems != null)
                        {
                            var basketModel = new BasketViewModel()
                            {
                                BasketItems = basketItems.Select(x => {
                                    var product = productService.GetProduct(x.ProductId);
                                    return new BasketItemModel()
                                    {
                                        ProductId = product.Id,
                                        Name = product.Name,
                                        Price = product.Price,
                                        Quantity = x.Quantity
                                    };
                                }).ToArray(),
                                PriceItem = new PriceItemModel()
                                {
                                    Currency = LibraryLayer.Enums.Currency.EUR,
                                    Price = Math.Round(basket.TotalPrice, 2)
                                }
                            };

                            return View(basketModel);
                        }
                        else
                            return View();
                    }
                    else
                        return View();
                }
                else
                    return View();
            }
            else
                return View();
        }
    }
}