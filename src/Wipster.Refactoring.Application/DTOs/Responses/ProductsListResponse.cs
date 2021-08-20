using System.Collections.Generic;

namespace Wipster.Refactoring.Application.Dtos
{
    public class ProductsListResponse
    {
        public IList<ProductResponse> Products { get; set; } = new List<ProductResponse>();

        public bool CreateEnabled { get; set; }
    }
}
