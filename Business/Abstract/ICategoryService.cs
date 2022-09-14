using Core.Utilities.Results;
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
       
       IDataResult< List<Category>> GetAll();//Tümünü listeler
        IDataResult<List<Category>> GetById(int categoryId);//Filtreli şekilde CategoryId'lerde listeleme işlemi gerçekleştirilir.
        
        
    
    }
}
