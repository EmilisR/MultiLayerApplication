using Basket.Service;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using LibraryLayer;

namespace BasketBLService
{
    [ServiceContract]
    public interface IBasketBLService
    {
        [OperationContract]
        decimal PayForBasket(string userMail, Enums.PaymentType paymentType, decimal moneyGiven = 0);

        [OperationContract]
        bool AddToBasket(string userMail, int itemId);

        [OperationContract]
        BLBasket GetBasketInfo(string userMail);

        [OperationContract]
        BasketItemInfo[] GetBasketItemsInfo(int basketId);
    }

    [DataContract]
    public class BasketItemInfo
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class BLBasket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Enums.PaymentType PaymentType { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public int? CustomerId { get; set; }
        [DataMember]
        public DateTime RegisterDate { get; set; }
        [DataMember]
        public bool Paid { get; set; }
        [DataMember]
        public BasketItem[] BasketItems { get; set; }
        [DataMember]
        public Enums.Currency Currency { get; set; }
    }
}
