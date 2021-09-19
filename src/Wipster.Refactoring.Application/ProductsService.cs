using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Application.Dtos;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Domain;

namespace Wipster.Refactoring.Application
{
    public class ProductsService : IProductsService
    {
        /* public IList<Product> GetProductsList()
         {
             using (var db = new NorthwindDbContext())
             {
                 var result = db.Products.ToList();
                 return result;
             }
         }

         public List<Product> GetProductsStartsWith(string name)
         {
             using (var db = new NorthwindDbContext())
             {
                 var sql = "SELECT * FROM Products WHERE ProductName LIKE '" + name + "%'";
                 var result = db.Products.FromSqlRaw(sql).ToList();
                 return result;
             }
         }

         public Product GetProduct(int productId)
         {
             using (var db = new NorthwindDbContext())
             {
                 var result = db.Products
                     .Where(p => p.ProductId == productId)
                     .FirstOrDefault();
                 return result;
             }
         }

         public Product CreateProduct(ProductRequest request)
         {
             return new Product();
         }

         public Product UpdateProduct(int id, ProductRequest request)
         {
             return new Product();
         }

         public void DeleteProduct(int productId)
         {

         }
        */

        private readonly NorthwindDbContext _dbContext;

        public ProductsService(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            var result = await _dbContext.Products.ToListAsync();
            return result;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _dbContext.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task CreateProductAsync(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }
            else
            {
                var result = await _dbContext.Products.AddAsync(newProduct);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProductAsync(Product updateProduct)
        {
            await _dbContext.SaveChangesAsync();
        }

       
        public Task<int> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

    }
}
