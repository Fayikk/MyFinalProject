using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()//Gönderilen parametreler için gerekli filtrelemeler gerçekleştiriliyor.
        where TContext: DbContext,new()//Aynı şekilde DbContext nesneleri gönderebilsin ve new'lenebilen sınıflar ile etkileşim'e geçilmelidir.
    {
        //Bir tabloyu ilgilendiren tüm operasyonlar için tekrardan birşeyler yazmayalım.
        //Temelimiz burası olsun.
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Referans tutucu ile adres tutuyoruz.
                addedEntity.State = EntityState.Added;//Referansı tutulan elemanın aslında eklenecek olan eleman olduğunu bildiriyoruz.
                context.SaveChanges();//Değişiklikleri kaydediyoruz.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
        //Predicates
        public TEntity Get(Expression<Func<TEntity, bool>> Filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(Filter);
            }
        }

        //Predicates
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (TContext context = new TContext())
            {
                return Filter == null ?
                    context.Set<TEntity>().ToList() ://Filtre null ise bu çalışacaktır.
                    context.Set<TEntity>().Where(Filter).ToList();//Eğer filtre null değil ise bu çalışacaktır.Filtreleyip ver anlamına gelmektedir.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}

