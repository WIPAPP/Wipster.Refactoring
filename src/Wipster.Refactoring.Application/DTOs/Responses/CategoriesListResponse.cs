using System.Collections.Generic;

namespace Wipster.Refactoring.Application.Dtos
{
    public class CategoriesListResponse
    {
        public IList<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        public int Count { get; set; }
    }
}
