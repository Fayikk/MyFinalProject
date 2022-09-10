using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
       
        List<Category> GetAll();//Tümünü listeler
        List<Category> GetById(int categoryId);//Filtreli şekilde CategoryId'lerde listeleme işlemi gerçekleştirilir.
        
        
    
    }
}
