using System.Collections.Generic;

namespace Wipster.Refactoring.Application.Dtos
{
    public class EmployeesListResponse
    {
        public IList<EmployeeResponse> Employees { get; set; } = new List<EmployeeResponse>();
    }
}
 