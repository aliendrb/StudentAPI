using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VetAPI.Classes;
using VetAPI.Services;

namespace VetAPI.Controllers
{
    [ApiController]
    [Route("animal")]
    public class AnimalsController : ControllerBase
    {
        private IMockDb _mockDb;
        public AnimalsController(IMockDb mockDb) 
        {
            _mockDb = mockDb;
        }

        [HttpGet]
        public IActionResult GetAllAnimals() 
        {
            return Ok(_mockDb.GetAllAnimals());
        }

        [HttpGet("id")]
        public IActionResult GetId(int id) 
        {
            return Ok($"got animal with id: {id}");
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal) 
        {
            return Created($"animals/{animal.Id}", animal);
        }

        [HttpPut("id")]
        public IActionResult UpdateAnimal(Animal animal) 
        {
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteAnimal(int id) 
        {
            return Ok();
        }
    }
}
