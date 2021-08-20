using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsService _products;

        public ProductsController()
        {
            _products = new ProductsService();
        }

        [HttpGet]
        [Route("api/products/all")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _products.GetProductsList();
        }

        [HttpGet]
        [Route("api/products/get/{id}")]
        public Product Get(int id)
        {
            return _products.GetProduct(id);
        }

        [HttpGet]
        [Route("api/products/starts-with/{name}")]
        public List<Product> GetProductsByName(string name)
        {
            return _products.GetProductsStartsWith(name);
        }

        [HttpPost]
        [Route("api/products/create")]
        public Product CreateProduct([FromBody] ProductRequest payload)
        {
            return _products.CreateProduct(payload);
        }

        [HttpPatch("{id}")]
        [Route("api/products/update/{id}")]
        public Product UpdateProduct(int id, [FromBody] ProductRequest paylod)
        {
            return _products.UpdateProduct(id, paylod);
        }

        [HttpPost("{id}")]
        [Route("api/products/delete/{id}")]
        public void DeleteProduct(int id)
        {
            _products.DeleteProduct(id);
        }

    }
}