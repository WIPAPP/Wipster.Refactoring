using System.Threading.Tasks;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public interface IEmployeesService
    {
        Task<EmployeesListResponse> GetAllAsync();
        Task<EmployeesListResponse> GetAllByCityAsync(string city);
        Task<EmployeesListResponse> GetAllByCountryAsync(string country);
        Task<EmployeeResponse> GetByIdAsync(int id);
        Task<EmployeeResponse> UpdateAsync(int id, EmployeeRequest request);
        Task<EmployeeResponse> CreateAsync(EmployeeRequest request);
        Task<int> DeleteAsync(int id);
    }
}