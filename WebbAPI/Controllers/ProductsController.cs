using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebbAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;//Bağımlılığı ortadan kaldırmak için bir field oluşturuyoruz.
        public ProductsController(IProductService productService)
        {
            _productService = productService;   
        }

        [HttpGet("getall")]//Bu bir HttpGet gerçekleştiriyor.
        public IActionResult GetAll()
        {
            //Dependency Chain

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);//Döndürülen değer eğer success ise Ok("Bu bizim status code'umuzdur") bu ifadeyi döndür anlamına gelmektedir.
            }


            return BadRequest(result.Message);//Burada ise eğer cevap olumsuz ise bu değer döndürülecektir.
        }
        
        [HttpPost("add")]//Burada ise Post işlemi yapmamız gerekmektedir.
                  //Değerlerin değişimi vb.
                    //Güncelleme ve silme işlemleri içinde Post kullanılabilir.
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);//Ekleme operasyonunu gerçekleştireceğiz
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpGet("getbyId")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetBtId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
