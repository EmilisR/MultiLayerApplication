using Basket.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LibraryLayer.Enums;

namespace BasketBLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBasketBLService
    {
        [OperationContract]
        decimal PayForBasket(string userMail, decimal moneyGiven);

        [OperationContract]
        bool AddToBasket(string userMail, int itemId);

        [OperationContract]
        BLBasket GetBasketInfo(Basket.Service.Basket basket);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BasketBLService.ContractType".
    [DataContract]
    public class BLBasket
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
}
