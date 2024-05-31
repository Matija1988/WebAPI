
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web.Http;
using WebAPI.Model;
using static System.Net.Mime.MediaTypeNames;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiController
    {
       
         
        public ProductController()
        {
           
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<HttpResponseMessage> Get()
        {
            if (DataInit._products == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var data = DataInit._products;

            var json = JsonConvert.SerializeObject(data);

            HttpContent stringContent = new StringContent(json);

            System.Diagnostics.Debug.WriteLine("Test json: " + json);
            System.Diagnostics.Debug.WriteLine("Test string:" + stringContent);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = stringContent
            };

            System.Diagnostics.Debug.WriteLine("Test response: " + response);


            return response; 
        }

        [HttpPost]
        [Route("createproduct")]
        public HttpResponseMessage Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            int productId = product.Id;


            if (DataInit._products.Max(p => p.Id) == productId) 
            {
                productId++;
            }

            product.Id = productId;

            DataInit._products.Add(product);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpPut]
        [Route("UpdateProduct/{id:int}")]
        public  HttpResponseMessage Put([FromBody] Product product, int id)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var productFromList =  DataInit._products.Find(x => x.Id == id);   

            if(productFromList == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            int productID = product.Id;

            if (DataInit._products.Last().Id == productID) 
            { 
                productID++;
            };

            productFromList.Id = productID;
            productFromList.Name = product.Name;
            productFromList.Description = product.Description;
            productFromList.Owner = product.Owner;

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route("DeleteProduct/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var productFromList = DataInit._products.Find(x => x.Id == id);

            if (productFromList is null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            DataInit._products.Remove(productFromList);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("FindProductById/{id:int}")]

        public  HttpResponseMessage GetById(int id)
        {
            var productFromList = DataInit._products.Find(x=> x.Id == id);

            if (productFromList is null) 
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
