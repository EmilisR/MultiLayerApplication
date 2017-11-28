using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LibraryLayer.Enums;

namespace Basket.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
        void SetBasketPaymentType(int basketId, PaymentType paymentType);
    }
    [DataContract]
    public class Basket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public PaymentType PaymentType { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
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
