using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public class EmployeesService : IEmployeesService
    {
        private NorthwindDbContext _dbContext;

        public EmployeesService(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeesListResponse> GetAllAsync()
        {
            var result = await _dbContext.Employees.ToListAsync();
            var response = new EmployeesListResponse();

            foreach (var e in result)
            {
                response.Employees.Add(new EmployeeResponse
                {
                    Id = e.EmployeeId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    City = e.City,
                    Country = e.Country
                });
            }
            return response;
        }

        public async Task<EmployeesListResponse> GetAllByCountryAsync(string country)
        {
            var result = await _dbContext.Employees
                .Where(e => e.Country == country)
                .ToListAsync();
            var response = new EmployeesListResponse();

            foreach (var e in result)
            {
                response.Employees.Add(new EmployeeResponse
                {
                    Id = e.EmployeeId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    City = e.City,
                    Country = e.Country
                });
            }
            return response;
        }

        public async Task<EmployeesListResponse> GetAllByCityAsync(string city)
        {
            var result = await _dbContext.Employees
                .Where(e => e.City == city)
                .ToListAsync();

            var response = new EmployeesListResponse();
            foreach (var e in result)
            {
                response.Employees.Add(new EmployeeResponse
                {
                    Id = e.EmployeeId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    City = e.City,
                    Country = e.Country
                });
            }
            return response;
        }

        public async Task<EmployeeResponse> GetByIdAsync(int id)
        {
            var result = await _dbContext.Employees
                .Where(p => p.EmployeeId == id)
                .FirstOrDefaultAsync();

            return new EmployeeResponse
            {
                Id = result.EmployeeId,
                LastName = result.LastName,
                FirstName = result.FirstName,
                Title = result.Title,
                TitleOfCourtesy = result.TitleOfCourtesy,
                City = result.City,
                Country = result.Country
            };
        }

        public async Task<EmployeeResponse> CreateAsync(EmployeeRequest request)
        {
            var newItem = new Employee
            {
                EmployeeId = request.EmployeeId,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Title = request.Title,
                TitleOfCourtesy = request.TitleOfCourtesy,
                City = request.City,
                Country = request.Country
            };

            var result = await _dbContext.Employees.AddAsync(newItem);
            await _dbContext.SaveChangesAsync();

            return new EmployeeResponse
            {
                Id = result.Entity.EmployeeId,
                LastName = result.Entity.LastName,
                FirstName = result.Entity.FirstName,
                Title = result.Entity.Title,
                TitleOfCourtesy = result.Entity.TitleOfCourtesy,
                City = result.Entity.City,
                Country = result.Entity.Country
            };
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, EmployeeRequest request)
        {
            var item = await _dbContext.Employees.FindAsync(id);
            var result = _dbContext.Employees.Update(item);
            await _dbContext.SaveChangesAsync();

            return new EmployeeResponse
            {
                Id = result.Entity.EmployeeId,
                LastName = result.Entity.LastName,
                FirstName = result.Entity.FirstName,
                Title = result.Entity.Title,
                TitleOfCourtesy = result.Entity.TitleOfCourtesy,
                City = result.Entity.City,
                Country = result.Entity.Country
            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
