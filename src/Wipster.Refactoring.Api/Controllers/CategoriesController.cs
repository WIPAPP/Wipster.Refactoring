using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Domain;
using Wipster.Refactoring.Application;
using Newtonsoft.Json;
using AutoMapper;
using Wipster.Refactoring.Application.DTOs.Category;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _categoryService;
        private readonly IMapper _mapper;


        public CategoriesController(ICategoriesService categories, IMapper mapper)
        {
            _categoryService = categories;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetAllCategoryAsync()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            return Ok(_mapper.Map<IEnumerable<GetCategoryDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(_mapper.Map<GetCategoryDto>(result));
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var ctegoryModel = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.CreateCategoryAsync(ctegoryModel);

            var getCategoryDto = _mapper.Map<GetCategoryDto>(ctegoryModel);
            return Ok(getCategoryDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var categoryFromDomain = await _categoryService.GetCategoryByIdAsync(id);

            if (categoryFromDomain != null)
            {
                _mapper.Map(updateCategoryDto, categoryFromDomain);
                _ = _categoryService.UpdateCategoryAsync(categoryFromDomain);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }
       
    }
}
