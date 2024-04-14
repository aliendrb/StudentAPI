using Microsoft.AspNetCore.Http.HttpResults;
using VetAPI.Classes;
namespace VetAPI.Services
{
    public interface IMockDb 
    {
        public ICollection<Animal> GetAllAnimals();
        public Animal? AddAnimal(Animal animal);
        public Animal? GetAnimal(int id);
        public Animal? RemoveAnimal(int id);
        public ICollection<Visit> GetVisits(int id);
        public Visit? AddVisit(Visit visit, int id);
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
                    Color = "Black",
                    Visits = new List<Visit>()
                },
                new Animal
                {
                    Id = 2,
                    Name = "Pete",
                    Category = "Dog",
                    Mass = 3.6,
                    Color = "Brown",
                    Visits = new List<Visit>()
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

        public Animal? RemoveAnimal(int id) 
        {
            var animal = _animals.FirstOrDefault(animal =>animal.Id == id);
            if (animal is null) return null;
            _animals.Remove(animal);
            return animal;
        }

        public ICollection<Visit> GetVisits(int id) 
        {
            var animal = _animals.FirstOrDefault(animal => animal.Id == id);
            if (animal is null) return null;
            List<Visit> visits = animal.Visits;
            return visits;
        }

        public Visit? AddVisit(Visit visit, int id) 
        {
            var animal = _animals.FirstOrDefault(animal => animal.Id == id);
            if (animal is null) return null;
            animal.Visits.Add(visit);
            return visit;
        }
    }
}
