﻿
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;

namespace DataAccesses.Concrete.EntityFramework
{
    //context:db ile proje claslarını ilişilendirmek için
    public class CarRentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarService;Trusted_connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors{ get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
