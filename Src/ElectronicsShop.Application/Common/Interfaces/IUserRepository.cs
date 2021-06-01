using ElectronicsShop.Domain.Models;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginUser(string email, string password);
        Task<User> LoginAdmin(string email, string password);
    }
}
