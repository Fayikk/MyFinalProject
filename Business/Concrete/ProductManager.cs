using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Varsa iş kodlarımızı buraya yazıyoruz.
            //Bir iş sınıfı başka sınıfları new'lemez
            //Yetkisi varmı?
            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
            //Burada ise filtreleme işlemlerimizi gerçekleştirmmiş oluyoruz.
            //Filtremizi verirken diyoruzki olurda p için categoryId'miz,eğer ıd'ye eşit oluyorsa.
            //bunu döndürelim.
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            //Burada 2 fiyat aralığında olan data'yı bize getirme işlemini  gerçekleştirecektir.
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
