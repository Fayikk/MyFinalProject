using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        //Bağımlılığımızı minimize ediyoruz.
        //Ve gerekli olan bağımlılıklarımzı constructor ınjection ile yapacağız.
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            //Bu olaya generate constuctor denmektedir.
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            
            return new DataResultt<List<Category>>(_categoryDal.GetAll(),true,Messages.ListId);
            //Filtre vermiyoruz çünkü tüm kategorileri listelemek istiyorum.
        }

        public IDataResult<List<Category>> GetById(int categoryId)
        {
            //Filtreleme işlemi gerçekleştiriyoruz.CategoryId'ye göre.

            

            return new DataResultt<List<Category>>(_categoryDal.GetAll(a => a.CategoryId == categoryId),true,Messages.NotSuccess);
        
        }

       
    }
}
