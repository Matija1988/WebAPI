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

            if(ownerFromList == null)
            {
                return NotFound("No owner with id " + id + " in database!");
            }

            ownerFromList.Id = owner.Id;
            ownerFromList.Name = owner.Name;
            
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOwner/{id:int}")]
        public IActionResult Delete(int id) 
        { 
            var ownerToDelete = DataInit._owners.Find(x =>x.Id == id);

            if (ownerToDelete != null)
            {
                DataInit._owners.Remove(ownerToDelete);
                return Ok();
            }

            return NotFound("No owner with id " + id + " in database!");
        }

        [HttpGet]
        [Route("FindOwnerById/{id:int}")]
        public IActionResult FindById(int id) 
        { 
            var ownerFromList = DataInit._owners.Find(x => x.Id == id);

            if (ownerFromList == null) 
            {
                return NotFound();
            
            }

            return Ok(ownerFromList);
        
        }

    }
}
