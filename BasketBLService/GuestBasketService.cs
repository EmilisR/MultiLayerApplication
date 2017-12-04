using System;
using LibraryLayer;
using User.Service;
using Basket.Service;
using NotificationService;
using Unity;
using Product.Service;
using System.Linq;

namespace BasketBLService
{
    public class GuestBasketService : IBasketBLService
    {
        private static Basket.Service.Basket _guestBasket;

        private static Basket.Service.Basket guestBasket
        {
            get
            {
                if (_guestBasket == null)
                {
                    var basketService = DependencyFactory.Container.Resolve<IBasketService>();
                    _guestBasket = GuestBasketFactory.CreateBasket();
                    return _guestBasket;
                }
                else
                    return _guestBasket;
            }
            set
            {
                _guestBasket = value;
            }
        }

        public static BLBasket GetGuestBasket()
        {
            var basketBl = new BLBasket();
            var basket = new Basket.Service.Basket();
            if (guestBasket != null)
            {
                var basketService = DependencyFactory.Container.Resolve<IBasketService>();
                basket = basketService.GetBasketById(guestBasket.Id);
            }
            return new BLBasket()
            {
                TotalPrice = basket.TotalPrice,
                Currency = Enums.Currency.EUR,
                PaymentType = basket.PaymentType,
                Id = basket.Id,
                Paid = basket.Paid,
                RegisterDate = guestBasket.RegisterDate
            };
        }

        public bool AddToBasket(string userMail, int itemId)
        {
            var basketService = DependencyFactory.Container.Resolve<IBasketService>();

            if (guestBasket != null && guestBasket.Id != 0)
            {
                return !basketService.AddItemToBasket(guestBasket.Id, itemId);
            }

            return false;
        }

        public BLBasket GetBasketInfo(string userMail)
        {
            BLBasket result = null;

            var basketService = DependencyFactory.Container.Resolve<IBasketService>();
            if (guestBasket != null)
            {
                var basketItems = basketService.GetBasketItems(guestBasket.Id);
                if (basketItems != null)
                {
                    result = new BLBasket()
                    {
                        BasketItems = basketItems,
                        TotalPrice = Math.Round(guestBasket.TotalPrice, 2),
                        Currency = Enums.Currency.EUR,
                        Id = guestBasket.Id,
                        RegisterDate = guestBasket.RegisterDate,
                        CustomerId = guestBasket.CustomerId,
                        Paid = guestBasket.Paid,
                        PaymentType = guestBasket.PaymentType
                    };
                }
            }
            return result;
        }

        public BasketItemInfo[] GetBasketItemsInfo(int basketId)
        {
            var productService = DependencyFactory.Container.Resolve<IProductService>();
            var basketService = DependencyFactory.Container.Resolve<IBasketService>();

            var basketItems = basketService.GetBasketItems(basketId);
            if (basketItems == null)
                return null;
            return basketItems.Select(x =>
            {
                var product = productService.GetProduct(x.ProductId);
                return new BasketItemInfo()
                {
                    Name = product.Name,
                    Price = product.Price,
                    ProductId = product.Id,
                    Quantity = x.Quantity
                };
            }).ToArray();
        }

        public decimal PayForBasket(string userMail, Enums.PaymentType paymentType, decimal moneyGiven = 0)
        {
            var basketService = DependencyFactory.Container.Resolve<IBasketService>();

            if (guestBasket != null && !guestBasket.Paid)
            {
                if (paymentType == Enums.PaymentType.Cash && guestBasket.TotalPrice <= moneyGiven)
                {
                    basketService.SetBasketPaid(guestBasket.Id);
                    basketService.SetBasketPaymentType(guestBasket.Id, paymentType);
                    var result = moneyGiven - guestBasket.TotalPrice;
                    guestBasket = null;
                    return result;
                }
                if (paymentType == Enums.PaymentType.CreditCard)
                {
                    basketService.SetBasketPaid(guestBasket.Id);
                    basketService.SetBasketPaymentType(guestBasket.Id, paymentType);
                    guestBasket = null;
                    return 0;
                }
            }

            return -1;
        }
    }
}
