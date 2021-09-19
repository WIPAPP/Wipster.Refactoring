using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Application;
using AutoMapper;
using Wipster.Refactoring.Application.DTOs.Employee;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService employees, IMapper mapper)
        {
            _employeesService = employees;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmpDto>>> GetAllEmpAsync([FromQuery] string country)
        {
            if (country != null)
            {
                return Ok(_mapper.Map<IEnumerable<GetEmpDto>>(await _employeesService.GetAllEmpByCountryAsync(country)));
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<GetEmpDto>>(await _employeesService.GetAllEmpAsync()));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmpDto>> GetEmpByIdAsync(int id)
        {
            var result = await _employeesService.GetEmpByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<GetEmpDto>(result));
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetEmpDto>> CreateEmpAsync(CreateEmpDto createEmpDto)
        {
            var empModel = _mapper.Map<Employee>(createEmpDto);
            await _employeesService.CreateEmpAsync(empModel);

            var getEmpDTO = _mapper.Map<GetEmpDto>(empModel);
            return Ok(getEmpDTO);
        }

        //PUT/API
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmp(int id, UpdateEmpDto updateEmpDTO)
        {
            var EmpModelFromDomain = await _employeesService.GetEmpByIdAsync(id);

            if (EmpModelFromDomain != null)
            {
                //mapper has alrady mapped data from dto to DomainModel
                //you dnt have to perform any more action other than save to save updates 
                _mapper.Map(updateEmpDTO, EmpModelFromDomain);

                //still going to call update as a good practise
                _ = _employeesService.UpdateEmpAsync(EmpModelFromDomain);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmpAsync(int id)
        {
            var EmpModelFromDomain = await _employeesService.GetEmpByIdAsync(id);

            if (EmpModelFromDomain != null)
            {
                _ = _employeesService.DeleteEmpAsync(EmpModelFromDomain);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
