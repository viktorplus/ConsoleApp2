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
/*    create table[Style]
(  [Id] int not null identity(1, 1) primary key,
   [Name] nvarchar(100) not null,
);
    create table[Studio]
(  [Id] int not null identity(1, 1) primary key,
   [Name] nvarchar(100) not null,
);

Create table[Game] 
(
    [Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null,
    [IdStudio] int foreign key references Studio(Id),
	[IdStyle] int foreign key references Style(Id),
	[Date] Date not null,
);*/