using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ZooToAnimal
    {
        public int Id { set; get; }
        public int Id_Zoo { set; get; }
        public int Id_Animal { set; get; }

        public ZooToAnimal()
        {
        }
        public ZooToAnimal(int zooId, int animalId)
        {
            Id_Zoo = zooId;
            Id_Animal = animalId;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, ZooId: {Id_Zoo}, AnimalId: {Id_Animal}");
        }
    }
}
