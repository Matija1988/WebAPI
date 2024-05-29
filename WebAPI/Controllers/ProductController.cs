using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       

        public ProductController()
        {
           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return null;
        }

        //public List<Product> GetProducts() 
        //{ 
         
        
        
        //}
    }
}
