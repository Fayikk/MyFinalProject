using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUı // Note: actual namespace depends on the project name.
{   //Her 3 katmanında referansını alacaktır(Data Access,Entity,Business) katmanı.
   
   //SOLID Prensiplerinde= Open/Closed prensiplerini uygulamış oluyoruz. 
    
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName+" - "+product.CategoryId+" - "+product.UnitPrice);
            //}
            foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName+" - "+product.UnitPrice);
            }
        }
    }
}