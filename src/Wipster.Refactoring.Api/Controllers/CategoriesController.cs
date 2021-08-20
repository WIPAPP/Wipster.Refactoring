using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;
using Newtonsoft.Json;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _categories;

        public CategoriesController(ICategoriesService categories)
        {
            _categories = categories;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriesListResponse>> GetAll()
        {
            var result = await _categories.GetAll();
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> Get(int id)
        {
            var result = await _categories.Get(id);
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> Create([FromBody] CategoryRequest request)
        {
            var result = await _categories.Create(request);
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponse>> Update(int id, [FromBody] CategoryRequest request)
        {
            var result = await _categories.Update(id, request);
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _categories.Delete(id);
            return Ok(Content(JsonConvert.SerializeObject(result), "application/json"));
        }
    }
}
