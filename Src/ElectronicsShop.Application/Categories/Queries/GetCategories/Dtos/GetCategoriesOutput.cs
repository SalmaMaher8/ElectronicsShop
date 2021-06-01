using ElectronicsShop.Domain.Models;
using System.Collections.Generic;

namespace ElectronicsShop.Application.Categories.Queries.GetCategories.Dtos
{
    public class GetCategoriesOutput
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
