using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class GameContext : DbContext
    {
        public string connectionString = @"Data Source=HomeDE\SQLEXPRESS;Initial Catalog=GameDB;Integrated Security=True;Encrypt=False";
        public DbSet<Game> Game { set; get; }
        public DbSet<Studio> Studio { set; get; }
        public DbSet<Style> Style { set; get; }

        public GameContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
