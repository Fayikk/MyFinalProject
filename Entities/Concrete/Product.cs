using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Diğer katmanlarda buraya erişsinler diye kullanmaktayız
    //İnternal ifadesi projenin içerisideki bütün dosyalara erişim sağlanmaktadır.
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
