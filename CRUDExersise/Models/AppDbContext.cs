using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                EmailAlias = "lheinschke",
                LastName = "Heinschke",
                FirstName = "Stewart",
                MiddleName = "Lucilia",
                Office = "Miami",
                Region = "South"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                EmailAlias = "apietesch",
                LastName = "Pietesch",
                FirstName = "Shayna",
                MiddleName = "Archaimbaud",
                Office = "DC",
                Region = "East"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                EmailAlias = "pfarrow",
                LastName = "Farrow",
                FirstName = "Phelia",
                MiddleName = "Pavlov",
                Office = "Lexington",
                Region = "Central"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                EmailAlias = "skembley",
                LastName = "Kembley",
                FirstName = "Sharron",
                MiddleName = "Sherry",
                Office = "Phoenix",
                Region = "West"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                EmailAlias = "wmunroe",
                LastName = "Munroe",
                FirstName = "Willard",
                MiddleName = "Wally",
                Office = "Bozeman",
                Region = "North"
            });
        }
    }
}
