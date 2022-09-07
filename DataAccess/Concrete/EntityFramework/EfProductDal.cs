using DataAccess.Abstract;
using Entities.Concrete;
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
    public class EfProductDal : IProductDal
    {
        //NuGet package ortmaından paket indirmemiz gerekecektir.
        //EntityFramework ortamının kurulumunu gerçekleştiriyoruz.

        public void Add(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var addedEntity = context.Entry(entity);//Referans tutucu ile adres tutuyoruz.
                addedEntity.State=EntityState.Added;//Referansı tutulan elemanın aslında eklenecek olan eleman olduğunu bildiriyoruz.
                context.SaveChanges();//Değişiklikleri kaydediyoruz.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State=EntityState.Deleted;
                context.SaveChanges();

            }
        }
        //Predicates
        public Product Get(Expression<Func<Product, bool>> Filter)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Product>().SingleOrDefault(Filter);
            }
        }

        //Predicates
        public List<Product> GetAll(Expression<Func<Product, bool>> Filter = null)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return Filter == null ?
                    context.Set<Product>().ToList() ://Filtre null ise bu çalışacaktır.
                    context.Set<Product>().Where(Filter).ToList();//Eğer filtre null değil ise bu çalışacaktır.Filtreleyip ver anlamına gelmektedir.
            }
        }

        public void Update(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
