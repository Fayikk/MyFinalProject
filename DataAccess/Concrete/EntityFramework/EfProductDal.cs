using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{   //Entity Framework'e başlayalım
    //Entity framework ORM(Object Relational Mapping)=Veri tablosundaki tabloyu sanki class'mış gibi davranıp LINQ ile veri tabanı nesneleri arasında bir bağ kurup gerekli olan Db işlemlerini gerçekleştirmemize yarayacaktır.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        //NuGet package ortmaından paket indirmemiz gerekecektir.
        //EntityFramework ortamının kurulumunu gerçekleştiriyoruz.
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //Join process
                var result = from p in context.Products   //Ürünler ile 
                             join c in context.Categories //Kategorileri join et anlamına gelmektedir.
                             on p.CategoryId equals c.CategoryId //Buradaki ifade ise p'nin categoryId'si ile c'nin categoryId'si birbirine eşit ise;
                             select new ProductDetailDto {ProductId=p.ProductId,ProductName=p.ProductName,  //select ile seçim yapıp bellekte ProductDetailDto için yer açıyoruz.
                                                    UnitsInStock=p.UnitsInStock,CategoryName=c.CategoryName};//Gerekli olan veriler ilgili tablolar ile ilişkilendirerek 
                               return result.ToList();  //Döndürme ve yazdırma işlemleri gerçekleştiriliyor.
                                 
            }
        }
    }
}