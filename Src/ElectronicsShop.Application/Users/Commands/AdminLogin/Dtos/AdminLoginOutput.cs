using ElectronicsShop.Domain.Models;

namespace ElectronicsShop.Application.Users.Commands.AdminLogin.Dtos
{
    public class AdminLoginOutput
    {
        public bool Status { get; set; }
        public User User { get; set; }
    }
}
