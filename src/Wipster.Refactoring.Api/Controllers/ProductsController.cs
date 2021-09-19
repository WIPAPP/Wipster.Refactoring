using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;
using Wipster.Refactoring.Domain.Entities;
using AutoMapper;
using Wipster.Refactoring.Application.DTOs.Products;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService products, IMapper mapper)
        {
            _productService = products;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetAllProductAsync()
        {
            var result = await _productService.GetAllProductAsync();
            return Ok(_mapper.Map<IEnumerable<GetProductDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetProductByIdAsync(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<GetProductDto>(result));
            }
        }

        /*
        [HttpGet]
        [Route("api/products/starts-with/{name}")]
        public List<Product> GetProductsByName(string name)
        {
            return _products.GetProductsStartsWith(name);
        }
        */

        [HttpPost]
        public async Task<ActionResult<GetProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var productModel = _mapper.Map<Product>(createProductDto);
            await _productService.CreateProductAsync(productModel);

            var getProductDto = _mapper.Map<CreateProductDto>(productModel);
            return Ok(getProductDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var productFromDomain = await _productService.GetProductByIdAsync(id);

            if (productFromDomain != null)
            {
                _mapper.Map(updateProductDto, productFromDomain);
                _ = _productService.UpdateProductAsync(productFromDomain);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("{id}")]
        [Route("api/products/delete/{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProductAsync(id);
        }

    }
}