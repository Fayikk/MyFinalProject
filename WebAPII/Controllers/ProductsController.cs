using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]//Route bu insanlar bize nasıl ulaşssın
    [ApiController]//C#'ta ATTRIBUTE denmektedir.
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product{ProductId=1, ProductName="Portakal"},
                new Product { ProductId = 2, ProductName = "Vişne" }
            };
        }
    }
}
