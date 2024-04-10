using VetAPI.Classes;
namespace VetAPI.Services
{
    public interface IMockDb 
    {
        public ICollection<Animal> GetAllAnimals();
        public Animal? AddAnimal(Animal animal);
        public Animal? GetAnimal(int id);
    }
    public class MockDb : IMockDb
    {
        private ICollection<Animal> _animals;

        public MockDb() 
        {
            _animals = new List<Animal> 
            {
                new Animal 
                {
                    Id = 1,
                    Name = "Fluffy",
                    Category = "Cat",
                    Mass = 5.3,
                    Color = "Black"
                },

                new Animal
                {
                    Id = 2,
                    Name = "Pete",
                    Category = "Dog",
                    Mass = 3.6,
                    Color = "Brown"
                }
            };
        }

        public ICollection<Animal> GetAllAnimals() 
        {
            return _animals;
        }

        public Animal? AddAnimal(Animal animal) 
        {
            _animals.Add(animal);
            return animal;
        }

        public Animal? GetAnimal(int id) 
        {
            return _animals.FirstOrDefault(animal => animal.Id == id);
        }
    }
}
