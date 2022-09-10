using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DataAccess.Abstract
{
    //Unutmayın public diğer katmanlardan erişimi sağlayacaktır.
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //Category'e ait özel operasyonları buraya koyacağız
    }
}
