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
    public class UserRepository : IUserRepository
    {
        private readonly IElectronicsDbContext _context;

        public UserRepository(IElectronicsDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);

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

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginAdmin(string email, string password)
        {
            var user = await _context.Users.Include(u => u.UserRoles)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.UserRoles.Any(r => r.RoleId == 1));

            return user;
        }

        public async Task<User> LoginUser(string email, string password)
        {
            var user = await _context.Users.Include(u => u.UserRoles)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.UserRoles.Any(r => r.RoleId == 2));

            return user;
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
