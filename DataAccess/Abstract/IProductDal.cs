using Business.Abstract;
using Entities.Concrete;
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

    }
}
