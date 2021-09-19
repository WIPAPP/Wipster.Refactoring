using System.Collections.Generic;

namespace Wipster.Refactoring.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

       // public ICollection<Product> Products { get; private set; }
    }
}
