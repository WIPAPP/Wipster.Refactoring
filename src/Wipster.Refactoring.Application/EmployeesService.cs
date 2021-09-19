using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Domain;
using Wipster.Refactoring.Domain.Entities;


namespace Wipster.Refactoring.Application
{
    public class EmployeesService : IEmployeesService
    {
        private readonly NorthwindDbContext _dbContext;

        public EmployeesService(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmpAsync()
        {
            var result = await _dbContext.Employees.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllEmpByCountryAsync(string country)
        {
            var result = await _dbContext.Employees
                //.Find(e => e.Country == country)
                .Where(e => e.Country == country)
                .ToListAsync();


            /*
             *  var model = sessionList.Select(session => new StormSessionViewModel()
        {
            Id = session.Id,
            DateCreated = session.DateCreated,
            Name = session.Name,
            IdeaCount = session.Ideas.Count
        });
            */
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllEmpByCityAsync(string city)
        {
            var result = await _dbContext.Employees
                .Where(e => e.City == city).Select(e => new  Employee())
                .ToListAsync();

            return result;
        }

        public async Task<Employee> GetEmpByIdAsync(int id)
        {
            var result = await _dbContext.Employees
                .Where(p => p.EmployeeId ==id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task CreateEmpAsync(Employee newEmp)
        {
            if (newEmp == null)
            {
                throw new ArgumentNullException(nameof(newEmp));
            }
            else
            {
                var result = await _dbContext.Employees.AddAsync(newEmp);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task UpdateEmpAsync(Employee updateEmp)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmpAsync(Employee delEmp)
        {
            if (delEmp == null)
            {
                throw new ArgumentNullException(nameof(delEmp));
            }
            else
            {
                var result = _dbContext.Employees.Remove(delEmp);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
