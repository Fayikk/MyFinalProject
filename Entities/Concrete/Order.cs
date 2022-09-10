using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Bu class bizim için bir veritabanı nesnesidir.Dolayısıyla IEntity interface'ini kalıtım yolu ile almak zorundadır.
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }

        public int employeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
        
    }
}
