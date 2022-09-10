//using Business.Abstract;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence.Repositories;

namespace DataAccess.Abstract
{   //İsmindeki dal onun hhangi katmana karşılık geldiğini anlatmaktadır.
    public interface IProductDal:IEntityRepository<Product>//Burada sen IEntityRepository'yi product için yapılandırdın anlamına gelmektedir.
    {
        //Buraya sadece ürüne ait özel operasyonları koyacağız.
        //Yani şu şekilde gerçekleşmektedir.Gerekli olan yordamların,metodların interfaceler yardımıyla implementasyonları gerçekleştirilir.Ancak bununla beraber 
        //Class'ın kendine has,özgü metodları bulunabilir bu metodların kullanımı için bul class gayet uygundur.
        //ProdctDal'a özgü join ifadesi yazacağız
        List<ProductDetailDto> GetProductDetails();//Burada bir tür join ifadesi yazılacaktır.
       

    }
}
