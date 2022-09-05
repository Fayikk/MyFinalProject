using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{   //Bellekte ürün ile ilgili veri erişim kodlarının yazılacağı yer anlmaına gelmektedir.
    public class InMemoryProductDal : IProductDal
    {   
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                //Bu dosyaların bize herhangi bir veritabanından geliyormuş gibi düşünelim.(Sql,Oracle,Mongodb vs)
                //Ürünlerimizi bellek üzerinde prototipini gösteriyoruz.
                new Product{ProductId=1,CategoryId=1,ProductName="Tablet",UnitPrice=1000,UnitsInStock=20},
                new Product{ProductId=2,CategoryId=1,ProductName="Telefon",UnitPrice=750,UnitsInStock=25},
                new Product{ProductId=3,CategoryId=2,ProductName="Pantolon",UnitPrice=50,UnitsInStock=1000},
                new Product{ProductId=4,CategoryId=2,ProductName="SweatShirt",UnitPrice=60,UnitsInStock=60},
                new Product{ProductId=5,CategoryId=2,ProductName="Hat",UnitPrice=30,UnitsInStock=750},

            };
            //Burada constructor sayesinde 'InMemoryProductDal' her seferinde çalıştıtıldığı zaman constructor tetiklenecktir.
           
        }
        
        public void Add(Product product)
        {
            _products.Add(product);//Veri tabanı olarak kabul ettiğimiz bellek işlemlerimize ekleme işlemlerini bu şekilde gerçekleştiryoruz.
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//LINQ
            //Gönderilen p için,p'nin productıd'si (Foreach gibi düşünecek olursak) metoda gönderilen product'ın,productıd'si ile eşit ise SingleOrDefault metodu ile bu nesnenin referansını tutarak
            //productToDelete geçici değişkenine,nesnemizin referans adresimizin atamasını yapıyoruz.Ve bu değişkeni Remove() komutu ile silme işlemini gerçekleştiriyoruz.
            _products.Remove(productToDelete);//Silme işlemi burada gerçekleşecektir.
        }

        public List<Product> GetAll()
        {
            //Veri  tabanındaki  data'yı business'a vermemiz gerekmektedir.
            return _products;//verileri kaydettiğimiz bölgeyi olduğu gibi döndürüyoruz.
        }

        public List<Product> GettAllByCatefory(int categoryId)
        {
            
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğimiz ÜrünID'sine sahip olan ürünü bul anlamına gelmektedir.
            
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.ProductId=product.ProductId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
            //Şeklinde atamalarımızı gerçekleştirebiliriz.

        }
    }
}
