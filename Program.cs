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
                using (GameContext db = new GameContext())
                {
                   var styles = db.Style.ToList();
                   var studios = db.Studio.ToList();
                   var games = db.Game.ToList();

                   var query = from game in games
                       join studio in studios on game.IdStudio equals studio.Id
                       join style in styles on game.IdStyle equals style.Id
                       select new
                       {
                           GameName = game.Name,
                           StudioName = studio.Name,
                           StyleGame = style.Name,
                           DataGame = game.Date
                       };

                    foreach (var item in query)
                    {
                        Console.WriteLine($"GameName: {item.GameName}, StudioName: {item.StudioName}, StyleGame: {item.StyleGame}, DateGame: {item.DataGame}");
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


/*                using (AnimalContext db = new AnimalContext())
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
                }*/