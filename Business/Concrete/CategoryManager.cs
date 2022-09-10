using Business.Abstract;
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

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
            //Filtre vermiyoruz çünkü tüm kategorileri listelemek istiyorum.
        }

        public List<Category> GetById(int categoryId)
        {
            //Filtreleme işlemi gerçekleştiriyoruz.CategoryId'ye göre.
            return _categoryDal.GetAll(a => a.CategoryId == categoryId);
        
        }
    }
}
