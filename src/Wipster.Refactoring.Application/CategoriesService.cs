using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Domain;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public class CategoriesService : ICategoriesService
    {
        private readonly NorthwindDbContext _dbContext;

        public CategoriesService(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var result = await _dbContext.Categories.ToListAsync();
            return result;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var result = await _dbContext.Categories
                .Where(p => p.CategoryId == id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task CreateCategoryAsync(Category newCategory)
        {
            if (newCategory == null)
            {
                throw new ArgumentNullException(nameof(newCategory));
            }
            else
            {
                var result = await _dbContext.Categories.AddAsync(newCategory);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCategoryAsync(Category updateCategory)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var item = await _dbContext.Categories.FindAsync(id);
            _dbContext.Categories.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

    }
}
