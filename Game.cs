using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Game
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int IdStudio { get; set; }
        public int IdStyle {  get; set; }
        public DateTime Date {get;set; }
        public Game() { }
        public Game(string name, int idstudio, int idstyle, DateTime date)
        {
            Name = name;
            IdStudio = idstudio;
            IdStyle = idstyle;
            Date = date;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name Game: {Name}, IdStudio: {IdStudio}, IdStyle: {IdStyle}, Date: {Date}" );
        }
    }
}

