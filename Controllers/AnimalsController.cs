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

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id) 
        {
            var animal = _mockDb.GetAnimal(id);
            if (animal is null) return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal) 
        {
            _mockDb.AddAnimal(animal);
            return Created($"animals/{animal.Id}", animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(Animal animal, int id) 
        {
            if (_mockDb.RemoveAnimal(id) is null) return NotFound();
            _mockDb.AddAnimal(animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id) 
        {
            var animal = _mockDb.GetAnimal(id);
            if (animal is null) return NotFound();
            _mockDb.RemoveAnimal(id);
            return NoContent();
        }
    }
}
