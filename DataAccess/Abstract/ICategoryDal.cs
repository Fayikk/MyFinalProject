using Business.Abstract;
using Entities.Astract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Unutmayın public diğer katmanlardan erişimi sağlayacaktır.
    public interface ICategoryDal:IEntityRepository<Category>
    {
        
    }
}
