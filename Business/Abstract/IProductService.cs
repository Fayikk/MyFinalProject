using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{//Data Acces ve Entities referans olarak alacaktır.
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();//Burada yapılmak istenen mesaj ile birlikte veri döndürme işlemide gerçekleşsin diyorsak
        //IDataResult yapısı şeklindeki yapılar kullanılacaktır.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        
        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
        

        IDataResult<Product> GetBtId(int productId);
        //Dataya sahip olanların hepsi IDataResult olarak tanımlandı.

        IResult Add(Product product);

    }
}
