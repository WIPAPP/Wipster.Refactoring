using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesService EmployeesService;

        public EmployeesController(IEmployeesService employees)
        {
            EmployeesService = employees;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeesListResponse>> GetAll([FromQuery] string country)
        {
            if (country != null)
            {
                return Ok(await EmployeesService.GetAllByCountryAsync(country));
            }
            else
            {
                return Ok(await EmployeesService.GetAllAsync());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetAsync(int id)
        {
            var result = await EmployeesService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateAsync([FromBody] EmployeeRequest request)
        {
            var productId = await EmployeesService.CreateAsync(request);
            return Ok(productId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponse>> UpdateAsync(int id, [FromBody] EmployeeRequest request)
        {
            var result = await EmployeesService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await EmployeesService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
