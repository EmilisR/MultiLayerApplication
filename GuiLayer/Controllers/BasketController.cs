using GuiLayer.Models;
using System.Linq;
using System.Web.Mvc;
using Unity;
using LibraryLayer;
using BasketBLService;

namespace GuiLayer.Controllers
{
    public class BasketController : Controller
    {
        [HttpPost]
        public ActionResult AddToBasket(int itemId)
        {
            if (AccountController.LoggedIn && UnityConfig.Container.Resolve<IBasketBLService>().GetType() != typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();

                basketService.AddToBasket(AccountController.Email, itemId);
            }
            else if (UnityConfig.Container.Resolve<IBasketBLService>().GetType() == typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();

                basketService.AddToBasket(AccountController.Email, itemId);
            }

            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket");
        }

        [HttpPost]
        public ActionResult PayForBasket(BasketViewModel model)
        {
            if (AccountController.LoggedIn && UnityConfig.Container.Resolve<IBasketBLService>().GetType() != typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();

                if (model.PaymentType == Enums.PaymentType.Cash)
                    basketService.PayForBasket(AccountController.Email, Enums.PaymentType.Cash, model.MoneyGiven);
                else
                    basketService.PayForBasket(AccountController.Email, Enums.PaymentType.CreditCard);
            }
            else if (UnityConfig.Container.Resolve<IBasketBLService>().GetType() == typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();
                    basketService.PayForBasket(AccountController.Email, Enums.PaymentType.CreditCard);
            }
            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket");
        }

        public ActionResult ViewBasket()
        {
            ViewBag.Message = "Pirkinių krepšelis";

            if (AccountController.LoggedIn && UnityConfig.Container.Resolve<IBasketBLService>().GetType() != typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();
                try
                {
                    var basket = basketService.GetBasketInfo(AccountController.Email);
                    var basketItems = basketService.GetBasketItemsInfo(basket.Id);
                    return View(new BasketViewModel()
                    {
                        BasketItems = basketItems.Select(x => new BasketItemModel()
                        {
                            Name = x.Name,
                            Price = x.Price,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity
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
            else if (UnityConfig.Container.Resolve<IBasketBLService>().GetType() == typeof(GuestBasketService))
            {
                var basketService = UnityConfig.Container.Resolve<IBasketBLService>();
                try
                {
                    var basket = GuestBasketService.GetGuestBasket();
                    var basketItems = basketService.GetBasketItemsInfo(basket.Id);
                    if (basketItems == null)
                        return View();
                    return View(new BasketViewModel()
                    {
                        BasketItems = basketItems.Select(x => new BasketItemModel()
                        {
                            Name = x.Name,
                            Price = x.Price,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity
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