using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Studio
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Country { set; get; }
        public string City { set; get; }


        public Studio()
        {
        }
        public Studio (string name, string country, string city)
        {
            Name = name;
            Country = country;
            City = city;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Country: {Country}, City: {City}");
        }
    }
}
