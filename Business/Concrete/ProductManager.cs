using Business.Abstract;
using Business.Constants;
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
        //[LogAspect]//bu ifade aşağıdaki Add metodunu log'la anlamına gelmektedi.
        //Bu ifadeye AOP denir.
        //[Validate]//Bunu doğrula anlamına gelmektedir.

        public IResult Add(Product product)
        {

            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);//görüldüğü üzere değişmezlerimizi tuttuğumuz class içerisinde 
                //magic strings karmaşıklığına sebebiyet vermeden static metodlarımız yardımı ile işimizi çözümlemiş olduk.
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//Burada mesaj döndürebilir yada boolean değer döndürmesi yapabilmektedir.
            //2 Parametreli ifadede hem mesaj değeri döndürürken aynı zamanda bool ifade değer döndürmektedir.
            //1 Parametreli ifadede ise sadece bool değer döndürmesi gerçekleştirilecektir.
            //yukarıdaki gibi bir değer döndürme işlemini gerçekleştirebilmemiz için
            //metodumuzun değer döndürdüğü sınıf'ın bir yapıcı metoda ihtiyacı vardır.
            //Yapıcı metodlar tetiklenme işlemlerini gerçekleştirirler.Dolayısıyla
            //ve yukarıdaki ifadeyi kullanabilmemizin yolu'da sııf için constructor'lardan geçmektedir.
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Varsa iş kodlarımızı buraya yazıyoruz.
            //Bir iş sınıfı başka sınıfları new'lemez
            //Yetkisi varmı?
            if (DateTime.Now.Hour==21)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);//Data döndürmüyorum
            }


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.Success);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
            //Burada ise filtreleme işlemlerimizi gerçekleştirmmiş oluyoruz.
            //Filtremizi verirken diyoruzki olurda p için categoryId'miz,eğer ıd'ye eşit oluyorsa.
            //bunu döndürelim.
        }

        public IDataResult<Product> GetBtId(int productId)
        {
            return new DataResultt<Product>(_productDal.Get(p => p.ProductId == productId),true,Messages.Success);//Delegasyon yöntemi
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //Burada 2 fiyat aralığında olan data'yı bize getirme işlemini  gerçekleştirecektir.
            return new DataResultt<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),false,"Error");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanceTime);//Data döndürmüyorum
            }
            return new DataResultt<List<ProductDetailDto>>(_productDal.GetProductDetails(),true,"Success");
        }
    }
}
