using ElectronicsShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Common.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetCategoryProductsAsync(int categoryId);
    }
}
