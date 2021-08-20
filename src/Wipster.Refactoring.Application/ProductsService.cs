using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Application.Dtos;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;

namespace Wipster.Refactoring.Application
{
    public class ProductsService
    {
        public IList<Product> GetProductsList()
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
    }
}
