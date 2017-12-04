using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using LibraryLayer;

namespace Basket.Service
{
    [ServiceContract]
    public interface IBasketService
    {
        [OperationContract]
        Basket GetBasketForUser(int userId);
        [OperationContract]
        BasketItem[] GetBasketItems(int basketId);
        [OperationContract]
        bool AddItemToBasket(int basketId, int productId);
        [OperationContract]
        void SetBasketPaid(int basketId);
        [OperationContract]
        void SetBasketPaymentType(int basketId, Enums.PaymentType paymentType);
        [OperationContract]
        Basket GetBasketById(int basketId);
    }
    [DataContract]
    public class Basket
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
    }
    [DataContract]
    public class BasketItem
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int BasketId { get; set; }
    }
}
