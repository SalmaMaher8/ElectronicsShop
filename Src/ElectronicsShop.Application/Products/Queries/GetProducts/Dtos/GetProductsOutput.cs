using ElectronicsShop.Domain.Models;
using System.Collections.Generic;

namespace ElectronicsShop.Application.Products.Queries.GetProducts.Dtos
{
    public class GetProductsOutput
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
