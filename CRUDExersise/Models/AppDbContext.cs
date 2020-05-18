using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging();
                //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
        }

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

            modelBuilder.Entity<Assignment>().HasKey(a => new { a.EmployeeId, a.ClientId });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 1,
                ClientId = 1,
                Role = "Senior Dev",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = new DateTime(2019, 06, 15)
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 1,
                ClientId = 2,
                Role = "Senior Dev",
                StartDate = new DateTime(2019, 6, 16),
                EndDate = null
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 2,
                ClientId = 1,
                Role = "Junior Dev",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = new DateTime(2019, 06, 15)
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 2,
                ClientId = 3,
                Role = "Senior Dev",
                StartDate = new DateTime(2019, 06, 16),
                EndDate = null
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 3,
                ClientId = 1,
                Role = "Manager",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = null
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 3,
                ClientId = 2,
                Role = "Manager",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = null
            });

            modelBuilder.Entity<Assignment>().HasData(new Assignment
            {
                EmployeeId = 3,
                ClientId = 3,
                Role = "Manager",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = null
            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 1,
                ClientName = "North Star Shipping"
            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 2,
                ClientName = "Ink and Block Press"
            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 3,
                ClientName = "Cottage Industry Inc"
            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 4,
                ClientName = "Lisa's lemonade"
            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 5,
                ClientName = "The Law Offices of Bob Loblaw"
            });
        }
    }
}
