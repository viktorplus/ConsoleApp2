using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AnimalContext : DbContext
    {
        public string connectionString = @"Data Source=HomeDE\SQLEXPRESS;Initial Catalog=AnimalDB;Integrated Security=True;Encrypt=False";
        public DbSet<Animal> Animal { set; get; }
        public DbSet<Zoo> Zoo { set; get; }
        public DbSet<ZooToAnimal> ZooToAnimal { set; get; }

        public AnimalContext()
        {    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

//    create table[Animal]
//(  [Id] int not null identity(1, 1) primary key,
//   [Name] nvarchar(100) not null,
//);
//    create table[Zoo]
//(  [Id] int not null identity(1, 1) primary key,
//   [Name] nvarchar(100) not null,
//);

//Create table[ZooToAnimal] (
//    [Id] int not null identity(1, 1) primary key,
//    [Id_Zoo] int foreign key references Zoo(Id),
//	  [Id_Animal] int foreign key references Animal(Id),
//	);
//}