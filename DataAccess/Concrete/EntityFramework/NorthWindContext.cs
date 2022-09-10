using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi Db tabloları ile proje classlarını bağlamak.
    public class NorthWindContext:DbContext//Entity Framework ile DbContext sınıfı gelmektedir.Context'imizin ta kendisidir.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bu method proje hangi veritabanı ile ilişkiliyi belirteceğimiz yerdir.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");//Sql server'a nasıl bağlacağını belirtmemiz yeterli olacaktır.
            //Veri tabanı ile ilgili işlemleri gerçekleştirdik.Peki ilgili işlemler nelerdi?
            //Oncellikle Entityframework'u nugget package'tan indirmesini gerçekleştiriyoruz.
            //EntityFramework'ün bir classı olan DbContext (bağlam olarak clasıımıza kalıtım ile veriyoruz),
            //OnConfiguring metodu ile gerekli veritabanı işlemlerimizi hangi ortamda yada hangi teknoloji ile yapacağımzı belirtiyoruz
            ////Bunu UseSqlServer diye belirterek sql ortamında gerçekleştireceğimizi belirliyoruz.
            ///Ve veritabanımızın yolunu Metod içerisine giriyoruz.
            ///Bu sayede veritabanı ile ilgili temel işlemleri gerçekleştirmiş oluyoruz.
            
        }
        public DbSet<Product> Products  { get; set; }//Product nesnemi veri tabanındaki Products ile bağla anlamına gelmektedir.
        public DbSet<Customer> Customers { get; set; }//Varlıklarımız içerisinde(Entities) bir adet Customer bulunmaktadır.Bunuda Bağlamış olduğumuz veritabanındaki Customers'a bağla diyoruz.

        public DbSet<Category> Categories { get; set; }//Ve son olarak Entities Projesi içerisinde bir adette Category class'ı bulunmaktadır.Bunuda verittabanından categories'e bağlıyoruz.Aslında belirtim yapıyoruz.

        //Artık bu sayede veritabanı işlemleriyle alakalı kodlarımızı Product,Customer,Category için yazabiliriz.
        public DbSet<Order> Orders { get; set; }//Benim 1 tane order nesnem var ve bunu orders ile ilişkilendirirmisin.
    }
}
