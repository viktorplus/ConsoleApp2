using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                   var animals = db.Animal.ToList();
                   var zoos = db.Zoo.ToList();
                   var zooToAnimals = db.ZooToAnimal.ToList();

                   var query = from zoo in zoos
                       join zooToAnimal in zooToAnimals on zoo.Id equals zooToAnimal.Id_Zoo
                       join animal in animals on zooToAnimal.Id_Animal equals animal.Id
                       select new
                       {
                           ZooName = zoo.Name,
                           AnimalName = animal.Name
                       };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"ZooName: {item.ZooName}, AnimalName: {item.AnimalName}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
