using System.Collections.Generic;
using System.Threading.Tasks;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task <Category> GetCategoryByIdAsync(int categoryId);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int categoryId);

    }
}