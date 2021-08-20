using System.Collections.Generic;
using System.Threading.Tasks;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    public interface ICategoriesService
    {
        Task<CategoriesListResponse> GetAll();
        Task<CategoryResponse> Get(int categoryId);
        Task<CategoryResponse> Create(CategoryRequest request);
        Task<CategoryResponse> Update(int categoryId, CategoryRequest request);
        Task<int> Delete(int categoryId);
    }
}