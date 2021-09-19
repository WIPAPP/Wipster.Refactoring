using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using System;
using Wipster.Refactoring.Api.Controllers;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Domain;
using Wipster.Refactoring.Domain.Entities;
using Xunit;
using AutoMapper;
using System.Threading.Tasks;
using Wipster.Refactoring.Application.DTOs.Employee;
using SolrNet.Utils;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.InMemory;


namespace Wipster.Refactoring.UnitTests
{
    public class EmployeesServiceTest
    {
        [Fact]
        public async Task GetAllEmpAsync_Should_Return_All_Employee_When_Calling_Without_Parameters()
        {

            var options = new DbContextOptionsBuilder<NorthwindDbContext>()
            .UseInMemoryDatabase(databaseName: "EmpListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NorthwindDbContext(options))
            {
                PopulateEmployee(context);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new NorthwindDbContext(options))
            {
                EmployeesService employeesService = new EmployeesService(context);
                IEnumerable<Employee> emp = await employeesService.GetAllEmpAsync();
    
            Assert.Equal(3, emp.Count());
            }
        }

        private static void PopulateEmployee(NorthwindDbContext context)
        {
            context.Employees.Add(new Employee { EmployeeId = 1, FirstName = "Emp 1" });
            context.Employees.Add(new Employee { EmployeeId = 2, FirstName = "Emp 2" });
            context.Employees.Add(new Employee { EmployeeId = 3, FirstName = "Emp 3" });
        }
    }

}
