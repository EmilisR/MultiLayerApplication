﻿using Basket.Service;
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
        decimal PayForBasket(string userMail, Enums.PaymentType paymentType, decimal moneyGiven);

        [OperationContract]
        bool AddToBasket(string userMail, int itemId);

        [OperationContract]
        BLBasket GetBasketInfo(string userMail);
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
        public int CustomerId { get; set; }
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
