using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Style
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public Style()
        {
        }
        public Style(string name)
        {
            Name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }
    }
}
