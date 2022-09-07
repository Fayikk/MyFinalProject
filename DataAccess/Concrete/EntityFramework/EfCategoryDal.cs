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
{
    //Entity Framework kullanımı
    //Yazılan kodlar reFactor edilecektir.(İyileştirilecektir9
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            //Bu yapı c# 'a özel çok güzel  ve özel bir yapıdır.
            //Burada using kullanmamızın sebebi NorthWind Context classı maliyetli bir class'tır ve bellekten işi bitince hemen silinmesi için
            //yani garbage collector'un gelip bu class'tan oluşturulan nesneyi silmesi için using metodu içerisinde tanımlama gerçekleştiriyoruz.
            //Kısacası daha performanslı bir yapıdır.
            using (NorthWindContext context=new NorthWindContext())
            {
                var addedEntity=context.Entry(entity);//Referansı yakalama
                addedEntity.State=EntityState.Added;//Referansı tutulan aslında eklenecek bir nesnedir.
                context.SaveChanges();//Şimdi yapılan değişiklikleri kaydet anlamlarına gelmektedirler.
               
            }
        }

        public void Delete(Category entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var deletedEntity = context.Entry(entity);//referans tutuldu
                deletedEntity.State= EntityState.Deleted;//Referansı tutulan değerin aslında silinecek bir eleamn olduğunu belirtiyoruz.
                context.SaveChanges();//Değişiklikleri kaydediyoruz

            }
        }

        public Category Get(Expression<Func<Category, bool>> Filter)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Category>().SingleOrDefault(Filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> Filter = null)
        {
            //Burada filtre verebilir,ancak eğer isterse filtre vermeyedebilir.
            using (NorthWindContext context = new NorthWindContext())
            {
                //Ternary operatörler
                return Filter == null ? context.Set<Category>().ToList() ://Ternary operatör kullandık burada,Filtre null ise bu değeri döndürecektir.
                    context.Set<Category>().Where(Filter).ToList() ;//Eğer filtre null değil ise bu ifadeyi döndürme işlemini gerçekleştirecektir.Filtreleyip ver anlamına gelmektedir.
            }

        }

        public void Update(Category entity)
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                var updatedEntity=context.Entry(entity);//Referans tutma işlemini gerçekleştirdik
                updatedEntity.State= EntityState.Modified;//Değiştirilecek eleman olduğunu belli ediyoruz.
                context.SaveChanges();//Değişiklikleri kaydediyoruz.

            }
        }
    }
}
