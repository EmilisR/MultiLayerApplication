using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LibraryLayer.Enums;

namespace Product.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetProduct(int itemId);
    }
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int QuantityInStock { get; set; }
        [DataMember]
        public int QuantityArriving { get; set; }
        [DataMember]
        public ProductCategory ProductCategory { get; set; }

    }

}
