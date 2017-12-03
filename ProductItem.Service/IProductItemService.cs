using LibraryLayer;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProductItemBLService
{
    [ServiceContract]
    public interface IProductItemService
    {
        [OperationContract]
        ProductItem[] GetAllProducts();

        [OperationContract]
        ProductItem GetProduct(int id);

        [OperationContract]
        bool AddNewProduct(ProductItem productItem);
    }

    [DataContract]
    public class ProductItem
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
        [DataMember]
        public string ImageUrl { get; set; }
    }
}
