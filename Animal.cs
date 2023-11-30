using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Animal
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public Animal()
        {
        }
        public Animal(string name)
        {
            Name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }
    }
}
