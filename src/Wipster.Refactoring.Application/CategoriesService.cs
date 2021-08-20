using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public class CategoriesService : ICategoriesService
    {
        private NorthwindDbContext _dbContext;

        public CategoriesService(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoriesListResponse> GetAll()
        {
            var result = await _dbContext.Categories.ToListAsync();
            return new CategoriesListResponse();
        }

        public async Task<CategoryResponse> Get(int id)
        {
            var result = await _dbContext.Categories
                .Where(p => p.CategoryId == id)
                .FirstOrDefaultAsync();

            return new CategoryResponse
            {
                Id = result.CategoryId,
                Name = result.CategoryName,
                Description = result.Description
            };
        }

        public async Task<CategoryResponse> Create(CategoryRequest request)
        {
            var newItem = new Category
            {
                CategoryName = request.Name,
                Description = request.Description
            };

            var result = await _dbContext.Categories.AddAsync(newItem);
            await _dbContext.SaveChangesAsync();

            return new CategoryResponse
            {
                Id = result.Entity.CategoryId,
                Name = result.Entity.CategoryName,
                Description = result.Entity.Description
            };
        }

        public async Task<CategoryResponse> Update(int id, CategoryRequest request)
        {
            var item = await _dbContext.Categories.FindAsync(id);
            var result = _dbContext.Categories.Update(item);
            await _dbContext.SaveChangesAsync();

            return new CategoryResponse
            {
                Id = result.Entity.CategoryId,
                Name = result.Entity.CategoryName,
                Description = result.Entity.Description
            };
        }

        public async Task<int> Delete(int id)
        {
            var item = await _dbContext.Categories.FindAsync(id);
            _dbContext.Categories.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
