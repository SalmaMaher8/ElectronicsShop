using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IElectronicsDbContext _context;

        public ProductRepository(IElectronicsDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);

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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetCategoryProductsAsync(int categoryId)
        {
            if(categoryId == new int())
            {
                return await _context.Products.ToListAsync();
            }

            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var product = await _context.Products.FindAsync(entity.Id);

            product = entity;

            if (await _context.SaveChangesAsync() > 0)
            {
                return entity;
            }

            return null;
        }
    }
}
