using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Business;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControler : ControllerBase
    {
        //Loosely coupled
        //IoC Container -->Inversion of Control(Kullanımı gerçekleştirmemeiz gerekmektedir.

        IProductService _productService;//Bağımlılığı ortadan kaldırmak için bir field oluşturuyoruz.
        public ProductsControler(IProductService productService)
        {
            //Constructor
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //Dependency Chain

            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
