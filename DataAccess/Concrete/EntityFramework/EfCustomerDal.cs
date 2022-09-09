using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //Referans oluşturma
                var addedEntity=context.Entry(entity);
                //eklenecek değer olduğunu belli etme,durumunu bildirme.
                addedEntity.State=Microsoft.EntityFrameworkCore.EntityState.Added;
                //Değişiklikleri kaydetme
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //Referans oluşturma
                var deletedEntity = context.Entry(entity);
                //eklenecek değer olduğunu belli etme,durumunu bildirme.
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                //Değişiklikleri kaydetme
                context.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> Filter)
        {
            //Değer döndürme işlemleri gerçekleştirilecektir ancak burada kullanılan filtre tek yönlü olduğu için ternary operatör kullanmamıza gerek yoktur.
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Customer>().SingleOrDefault(Filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> Filter = null)
        {
            //GetAll komutu kullanımını görelim.
            using (NorthWindContext context = new NorthWindContext())
            {
                //Değer döndürme işlemi yapılacaktır.
                //Ancak filtreleme işlemleride yapılmalıdır.
                //Çünkü değerimiz null olabilir yada olmayabilir.
                return Filter==null ? context.Set<Customer>().ToList():
                     context.Set<Customer>().Where(Filter).ToList();
            }
        }

        public void Update(Customer entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var updatedEntity = context.Entry(context);
                updatedEntity.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Değişiklikleri kaydet.
                context.SaveChanges();
            }
        }
    }
}
