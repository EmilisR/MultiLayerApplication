using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductItem.Service
{
    [ServiceContract]
    public interface IProductItemService
    {
        [OperationContract]
        ProductItem[] GetAllProducts();
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
