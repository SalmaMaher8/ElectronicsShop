using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IElectronicsDbContext _context;

        public OrderRepository(IElectronicsDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);

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

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ThenInclude(o => o.Product).ToListAsync();

            return orders;
        }

        public Task<Order> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
