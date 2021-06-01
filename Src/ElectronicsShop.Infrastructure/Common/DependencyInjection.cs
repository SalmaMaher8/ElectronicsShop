using ElectronicsShop.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ElectronicsShop.Infrastructure.Repositories;

namespace ElectronicsShop.Infrastructure.Common
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
            var connectionString = "Data Source=.;Initial Catalog=ElectronicsShop;Integrated Security=True";

            services.AddDbContext<ElectronicsDbContext>(options => options.UseSqlServer(connectionString));

			services.AddScoped<IElectronicsDbContext, ElectronicsDbContext>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();

			return services;
		}
	}
}
