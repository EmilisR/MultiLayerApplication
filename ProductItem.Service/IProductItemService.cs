using System.Drawing;
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
    }

    [DataContract]
    public class ProductItem
    {
        [DataMember]
        public Bitmap Image { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}
