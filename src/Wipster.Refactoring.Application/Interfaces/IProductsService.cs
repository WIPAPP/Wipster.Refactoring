using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Application
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
    }
}
