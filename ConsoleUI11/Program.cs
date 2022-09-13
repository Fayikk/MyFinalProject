using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CategoryTest();
            //Console.WriteLine("----------------------");
            //CustomerTest();
            ////Data Transformation Object (DTO) anlamına gelmektedir.(Veri dönüşüm nesnesi) 
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + " - " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        //private static void CustomerTest()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    foreach (var customer in customerManager.GetById("Wolza"))
        //    {
        //        Console.WriteLine(customer.CustomerId + " - " + customer.ContactName);
        //    }
        //}

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}