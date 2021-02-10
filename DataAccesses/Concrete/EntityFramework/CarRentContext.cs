using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesses.Concrete.EntityFramework
{
    //context:db ile proje claslarını ilişilendirmek için
   public class CarRentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarService;Trusted_connection=true");
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Colors> Colors{ get; set; }
        public DbSet<Brands> Brands { get; set; }
    }
}
