using System.Collections.Generic;
using System.Threading.Tasks;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Application
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetAllEmpAsync();
        Task<IEnumerable<Employee>> GetAllEmpByCityAsync(string city);
        Task<IEnumerable<Employee>> GetAllEmpByCountryAsync(string country);
        Task<Employee> GetEmpByIdAsync(int id);
        Task CreateEmpAsync(Employee emp);
        Task UpdateEmpAsync(Employee emp);
        Task DeleteEmpAsync(Employee emp);
    }
}