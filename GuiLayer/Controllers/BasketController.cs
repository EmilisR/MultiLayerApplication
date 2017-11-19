using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiLayer.Controllers
{
    public class BasketController : Controller
    {
        public ActionResult ViewBasket()
        {
            ViewBag.Message = "Pirkinių krepšelis";

            var basketItems = new BasketItemModel[]
                {
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 1
                    },
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 1
                    },
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 1
                    },
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 2
                    },
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 1
                    },
                    new BasketItemModel()
                    {
                        BasketId = 1,
                        Name = "Laptopas",
                        Price = 558.99M,
                        Quantity = 1
                    }
                };

            var basket = new BasketViewModel()
            {
                BasketItems = basketItems,
                PriceItem = new PriceItemModel()
                {
                    Currency = LibraryLayer.Enums.Currency.EUR,
                    Price = Math.Round(basketItems.Select(x => x.Price * x.Quantity).Sum(), 2)
                }
            };

            return View(basket);
        }
    }
}