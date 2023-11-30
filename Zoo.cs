using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Zoo
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public Zoo()
        {
        }
        public Zoo(string name)
        {
            Name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }
    }
}


