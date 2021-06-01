using ElectronicsShop.Application.Users.Commands.AdminLogin.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Users.Commands.AdminLogin
{
    public class AdminLoginCommand : IRequest<AdminLoginOutput>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
