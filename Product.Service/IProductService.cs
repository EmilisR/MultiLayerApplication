using System.Runtime.Serialization;
using LibraryLayer;
using System.ServiceModel;

namespace Product.Service
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetProduct(int itemId);

        [OperationContract]
        Product[] GetProductsArriving();
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
        public Enums.ProductCategory ProductCategory { get; set; }

    }

}
