using System;
using Basket.Service;
using User.Service;
using Unity;
using Product.Service;
using LibraryLayer;
using System.Linq;

namespace BasketBLService
{
    public class RegisteredUserBasketService : IBasketBLService
    {
        public RegisteredUserBasketService()
        {
            basketService = DependencyFactory.ResolveBasketService();
            userService = DependencyFactory.ResolveUserService();
            productService = DependencyFactory.ResolveProductService();
        }

        public IUserService userService { get; set; }
        public IBasketService basketService { get; set; }
        public IProductService productService { get; set; }

        public bool AddToBasket(string userMail, int itemId)
        {
            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null)
                {
                    return !basketService.AddItemToBasket(basket.Id, itemId);
                }
            }

            return false;
        }

        public BLBasket GetBasketInfo(string userMail)
        {
            BLBasket result = null;

            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null)
                {
                    var basketItems = basketService.GetBasketItems(basket.Id);
                    if (basketItems != null)
                    {
                        result = new BLBasket()
                        {
                            BasketItems = basketItems,
                            TotalPrice = Math.Round(basket.TotalPrice, 2),
                            Currency = Enums.Currency.EUR,
                            Id = basket.Id,
                            RegisterDate = basket.RegisterDate,
                            CustomerId = basket.CustomerId,
                            Paid = basket.Paid,
                            PaymentType = basket.PaymentType
                        };
                    }
                }
            }
            return result;
        }

        public BasketItemInfo[] GetBasketItemsInfo(int basketId)
        {
            var basketItems = basketService.GetBasketItems(basketId);
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
            var user = userService.GetUser(userMail);
            if (user != null)
            {
                var basket = basketService.GetBasketForUser(user.Id);
                if (basket != null && !basket.Paid)
                {
                    if (paymentType == Enums.PaymentType.Cash && basket.TotalPrice <= moneyGiven)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        basketService.SetBasketPaymentType(basket.Id, paymentType);
                        return moneyGiven - basket.TotalPrice;
                    }
                    if (paymentType == Enums.PaymentType.CreditCard)
                    {
                        basketService.SetBasketPaid(basket.Id);
                        basketService.SetBasketPaymentType(basket.Id, paymentType);
                        return 0;
                    }
                }
            }

            return -1;
        }
    }
}
