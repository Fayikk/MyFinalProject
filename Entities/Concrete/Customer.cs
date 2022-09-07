using Entities.Astract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity//IEntity interface'ini veriyoruz ve sen bir veritabanı nesnesisin diyoruz.Customer bir veri tabanı nesnesidir.
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
