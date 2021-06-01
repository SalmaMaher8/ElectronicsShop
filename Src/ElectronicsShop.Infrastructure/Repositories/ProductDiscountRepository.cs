using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Infrastructure.Repositories
{
    public class ProductDiscountRepository : IProductDiscountRepository
    {
        private readonly IElectronicsDbContext _context;

        public ProductDiscountRepository(IElectronicsDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDiscount> CreateAsync(ProductDiscount entity)
        {
            await _context.ProductDiscounts.AddAsync(entity);

            if (await _context.SaveChangesAsync() > 0)
            {
                return entity;
            }

            return null;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDiscount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDiscount> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDiscount> UpdateAsync(ProductDiscount entity)
        {
            throw new NotImplementedException();
        }
    }
}
