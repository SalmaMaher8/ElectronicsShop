using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ElectronicsShop.Infrastructure
{
    public class ElectronicsDbContext : DbContext, IElectronicsDbContext
    {
        public ElectronicsDbContext(DbContextOptions<ElectronicsDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectronicsDbContext).Assembly);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
