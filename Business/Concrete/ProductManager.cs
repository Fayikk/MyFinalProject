using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{   //Trying
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {

            if (product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır");
            }
       
            _productDal.Add(product);
            return new SuccessResult();//Burada mesaj döndürebilir yada boolean değer döndürmesi yapabilmektedir.
            //2 Parametreli ifadede hem mesaj değeri döndürürken aynı zamanda bool ifade değer döndürmektedir.
            //1 Parametreli ifadede ise sadece bool değer döndürmesi gerçekleştirilecektir.
            //yukarıdaki gibi bir değer döndürme işlemini gerçekleştirebilmemiz için
            //metodumuzun değer döndürdüğü sınıf'ın bir yapıcı metoda ihtiyacı vardır.
            //Yapıcı metodlar tetiklenme işlemlerini gerçekleştirirler.Dolayısıyla
            //ve yukarıdaki ifadeyi kullanabilmemizin yolu'da sııf için constructor'lardan geçmektedir.
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

        public Product GetBtId(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);//Delegasyon yöntemi
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            //Burada 2 fiyat aralığında olan data'yı bize getirme işlemini  gerçekleştirecektir.
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
