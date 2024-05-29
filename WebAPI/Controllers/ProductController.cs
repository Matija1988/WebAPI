using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebAPI.Model;
using WebAPI.Utilities;

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
            if (DataInit._products == null)
            {
                return NotFound();
            }

            return Ok(DataInit._products);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int productId = product.Id;

            DataInit._products.ForEach(x => { if (x.Id == productId) 
                {
                    productId++;
                }
            });

            product.Id = productId;

            DataInit._products.Add(product);

            return Ok(ResponseMessages.EntityCreated());

        }

        [HttpPut]
        [Route("UpdateProduct/{id:int}")]
        public async Task<IActionResult> Put([FromBody] Product product, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productFromList =  DataInit._products.Find(x => x.Id == id);   

            if(productFromList == null)
            {
                return NotFound();
            }

            productFromList.Id = product.Id;
            productFromList.Name = product.Name;
            productFromList.Description = product.Description;
            productFromList.Owner = product.Owner;

            return Ok();

        }

        [HttpDelete]
        [Route("DeleteProduct/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productFromList = DataInit._products.Find(x => x.Id == id);

            if (productFromList is null)
            {
                return NotFound();
            }

            DataInit._products.Remove(productFromList);

            return Ok();

        }
        [HttpGet]
        [Route("FindProductById/{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var productFromList = DataInit._products.Find(x=> x.Id == id);

            if (productFromList is null) 
            {
                return NotFound();
            }

            return Ok(productFromList);
        }


    }
}
