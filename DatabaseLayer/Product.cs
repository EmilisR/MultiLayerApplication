using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryLayer.Enums;

namespace DatabaseLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        public double Price { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
