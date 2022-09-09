using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{   //Entity Framework'e başlayalım
    //Entity framework ORM(Object Relational Mapping)=Veri tablosundaki tabloyu sanki class'mış gibi davranıp LINQ ile veri tabanı nesneleri arasında bir bağ kurup gerekli olan Db işlemlerini gerçekleştirmemize yarayacaktır.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>,IProductDal
    {
        //NuGet package ortmaından paket indirmemiz gerekecektir.
        //EntityFramework ortamının kurulumunu gerçekleştiriyoruz.


    }
}