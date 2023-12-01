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
        public DateOnly Date {get;set; }
        public string GameMode { get; set; }
        public int CopiesSold { get; set; }
        public Game() { }
        public Game(string name, int idstudio, int idstyle, DateOnly date, string gamemode, int copiessold)
        {
            Name = name;
            IdStudio = idstudio;
            IdStyle = idstyle;
            Date = date;
            GameMode = gamemode;
            CopiesSold = copiessold;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}, Name Game: {Name}, IdStudio: {IdStudio}, IdStyle: {IdStyle}, Date: {Date}" );
        }
    }
}

/* 
Install-Package Microsoft.EntityFrameworkCore.Tools

Add-Migration GameMigration1
To undo this action, use Remove-Migration.

Drop-Database
Update-Database
*/
