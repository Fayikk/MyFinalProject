using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUı // Note: actual namespace depends on the project name.
{   //Her 3 katmanında referansını alacaktır(Data Access,Entity,Business) katmanı.
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}