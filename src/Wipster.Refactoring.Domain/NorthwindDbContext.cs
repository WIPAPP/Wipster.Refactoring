using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Domain
{
    public class NorthwindDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            /*
            var dbFileName = "\\..\\..\\database\\Northwind_small.sqlite";
            var dbConnectionString = "Data Source=" + Environment.CurrentDirectory + dbFileName;
          
            options.UseSqlite(dbConnectionString);
            */
        }
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Territory> Territories { get; set; }
    }
}
