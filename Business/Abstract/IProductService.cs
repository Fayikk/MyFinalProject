﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{//Data Acces ve Entities referans olarak alacaktır.
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
