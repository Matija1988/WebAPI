using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {

   
        public OwnerController()
        {
           
        }

        [HttpGet]

        public IActionResult  Get()
        {
            if(DataInit._owners == null)
            {
                return NotFound();
            }

          return Ok(DataInit._owners);
         
        }

        [HttpPost]

        public IActionResult Post([FromBody] Owner owner)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest();
            }

            DataInit._owners.Add(owner);

            return Ok();

        }

        [HttpPut]
        [Route("UpdateOwner/{id:int}")]

        public IActionResult Put([FromBody] Owner owner, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ownerFromList = DataInit._owners.Find(x => x.Id == id);

            ownerFromList.Id = owner.Id;
            ownerFromList.Name = owner.Name;
            
            return Ok();
        }

        

    }
}
