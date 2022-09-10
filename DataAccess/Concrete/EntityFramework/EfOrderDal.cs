using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{   //Aslında burada yapılmak istene şudur EfEntityRepositoryBase içerisindeki metodların kalıtım yolu ile kullanılması istenmektedir.
    //Eğer her seferinde zorunlu hale getirilmesini istediğimiz bir metod var ise bunuda IOrderDal üzerinden gerçekleştirebiliriz.
    public class EfOrderDal:EfEntityRepositoryBase<Order,NorthWindContext>,IOrderDal
    {

    }
}
