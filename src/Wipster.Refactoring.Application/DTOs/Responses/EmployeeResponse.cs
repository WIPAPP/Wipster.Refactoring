using System;

namespace Wipster.Refactoring.Application.Dtos
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
