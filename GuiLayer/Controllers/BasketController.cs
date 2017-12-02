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

                if (model.PaymentType == Enums.PaymentType.Cash)
                    basketService.PayForBasket(AccountController.Email, Enums.PaymentType.Cash, model.MoneyGiven);
                else
                    basketService.PayForBasket(AccountController.Email, Enums.PaymentType.CreditCard);
            }
            var text = "Apmokėta sėkmingai";
            return RedirectToAction(nameof(BasketController.ViewBasket), "Basket", new { message = text});
        }

        public ActionResult ViewBasket()
        {
            ViewBag.Message = "Pirkinių krepšelis";

            if (AccountController.LoggedIn)
            {
                var basketService = UnityConfig.Container.Resolve<RegisteredUserBasketService>();
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
            else
                return View();
        }
    }
}