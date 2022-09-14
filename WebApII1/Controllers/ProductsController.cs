using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApII1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

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
